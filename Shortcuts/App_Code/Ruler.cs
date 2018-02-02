using System;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace Shortcuts {
	public class Ruler : System.Windows.Forms.Form {

		private System.Windows.Forms.ContextMenu contextMenu;
		private System.Windows.Forms.MenuItem menuItemFlip;
		private System.Windows.Forms.MenuItem menuItemSeparator1;
		private System.Windows.Forms.MenuItem menuItemPixel;
		private System.Windows.Forms.MenuItem menuItemInch;
		private System.Windows.Forms.MenuItem menuItemCentimeter;
		private System.Windows.Forms.MenuItem menuItemSeparator2;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.MenuItem menuItemExit;

		public Ruler() {
			//
			// Required for Windows Form Designer support
			//
			this.InitializeComponent();

			this.size = new Size(this.Width, this.Width);
			this.pen = new Pen(Color.Black, float.Epsilon);
			this.format = new StringFormat(StringFormat.GenericTypographic);
			this.format.FormatFlags = StringFormatFlags.NoWrap;
			this.format.Trimming = StringTrimming.Character;
		}

		private void Ruler_Load(object sender, System.EventArgs e) {
			this.ContextMenu = this.contextMenu;
			this.Horizontal = true;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ruler));
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItemFlip = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator1 = new System.Windows.Forms.MenuItem();
            this.menuItemPixel = new System.Windows.Forms.MenuItem();
            this.menuItemInch = new System.Windows.Forms.MenuItem();
            this.menuItemCentimeter = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator2 = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFlip,
            this.menuItemSeparator1,
            this.menuItemPixel,
            this.menuItemInch,
            this.menuItemCentimeter,
            this.menuItemSeparator2,
            this.menuItemAbout,
            this.menuItemExit});
            // 
            // menuItemFlip
            // 
            this.menuItemFlip.Index = 0;
            this.menuItemFlip.Text = "Flip Ruler";
            this.menuItemFlip.Click += new System.EventHandler(this.menuItemFlip_Click);
            // 
            // menuItemSeparator1
            // 
            this.menuItemSeparator1.Index = 1;
            this.menuItemSeparator1.Text = "-";
            // 
            // menuItemPixel
            // 
            this.menuItemPixel.Checked = true;
            this.menuItemPixel.Index = 2;
            this.menuItemPixel.Text = "Pixels";
            this.menuItemPixel.Click += new System.EventHandler(this.menuItemPixel_Click);
            // 
            // menuItemInch
            // 
            this.menuItemInch.Index = 3;
            this.menuItemInch.Text = "Inches";
            this.menuItemInch.Click += new System.EventHandler(this.menuItemInch_Click);
            // 
            // menuItemCentimeter
            // 
            this.menuItemCentimeter.Index = 4;
            this.menuItemCentimeter.Text = "Centimeters";
            this.menuItemCentimeter.Click += new System.EventHandler(this.menuItemCentimeter_Click);
            // 
            // menuItemSeparator2
            // 
            this.menuItemSeparator2.Index = 5;
            this.menuItemSeparator2.Text = "-";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 6;
            this.menuItemAbout.Text = "About Ruler...";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 7;
            this.menuItemExit.Text = "Exit Ruler";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // Ruler
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 60);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(45, 45);
            this.Name = "Ruler";
            this.Opacity = 0.75D;
            this.ShowInTaskbar = false;
            this.Text = "Ruler";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Ruler_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Ruler_Paint);
            this.DoubleClick += new System.EventHandler(this.menuItemFlip_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ruler_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ruler_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ruler_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Ruler_MouseUp);
            this.ResumeLayout(false);

		}
		#endregion

		//---------------------------------------------------------------------

		private Size size;

		private void EnsureVisible() {
			Rectangle screen = Screen.FromControl(this).Bounds;
			Rectangle ruler = this.Bounds;
			Rectangle r = Rectangle.Intersect(screen, ruler);
			int w = this.MinimumSize.Width / 2;
			if(r.Width < w) {
				this.Location = new Point(
					Math.Max(screen.X - ruler.Width + w, Math.Min(ruler.X, screen.Right - w)),
					this.Location.Y
				);
			}
			int h = this.MinimumSize.Height / 2;
			if(r.Height < h) {
				this.Location = new Point(
					this.Location.X,
					Math.Max(screen.Y - ruler.Height + h, Math.Min(ruler.Y, screen.Bottom - h))
				);
			}
		}

		private bool horizontal;
		private bool Horizontal {
			get { return this.horizontal; }
			set {
				this.horizontal = value;
				if(this.horizontal) {
					this.Size = new Size(this.size.Width, this.MinimumSize.Height);
				} else {
					this.Size = new Size(this.MinimumSize.Width, this.size.Height);
				}
				this.EnsureVisible();
			}
		}

		//---------------------------------------------------------------------

		private Point movePoint;
		private bool isMoving = false;
		private bool isLeftSizing = false;
		private bool isRightSizing = false;
		private bool isTopSizing = false;
		private bool isBottomSizing = false;

		private void Ruler_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
			if(e.Clicks <= 1 && e.Button == MouseButtons.Left) {
				if(this.Horizontal) {
					if(e.X <= 3) {
						this.isLeftSizing = this.Capture = true;
					} else if(e.X >= this.Width - 3) {
						this.isRightSizing = this.Capture = true;
					} else {
						this.isMoving = this.Capture = true;
					}
				} else {
					if(e.Y <= 3) {
						this.isTopSizing = this.Capture = true;
					} else if(e.Y >= this.Height - 3) {
						this.isBottomSizing = this.Capture = true;
					} else {
						this.isMoving = this.Capture = true;
					}
				}
				this.movePoint = this.PointToScreen(new Point(e.X, e.Y));
			}
		}
		private void Ruler_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
			if(this.Capture && e.Button == MouseButtons.Left) {
				this.isMoving =
				this.isLeftSizing =
				this.isRightSizing =
				this.isTopSizing =
				this.isBottomSizing =
				this.Capture = false;
				this.EnsureVisible();
				this.Invalidate();
			}
		}
		private void Ruler_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
			if(this.Capture) {
				Point p = this.PointToScreen(new Point(e.X, e.Y));
				Rectangle ruler = this.Bounds;
				Size min = this.MinimumSize;
				if(this.isMoving) {
					this.Location = new Point(
						ruler.X + p.X - this.movePoint.X,
						ruler.Y + p.Y - this.movePoint.Y
					);
				} else if(this.isLeftSizing) {
					this.Bounds = new Rectangle(
						ruler.X + p.X - this.movePoint.X,
						ruler.Y,
						ruler.Width - p.X + this.movePoint.X,
						min.Height
					);
					this.size.Width = this.Width;
				} else if(this.isRightSizing) {
					this.Size = new Size(ruler.Width + p.X - this.movePoint.X, ruler.Height);
					this.size.Width = this.Width;
				} else if(this.isTopSizing) {
					this.Bounds = new Rectangle(
						ruler.X,
						ruler.Y + p.Y - this.movePoint.Y,
						min.Width,
						ruler.Height - p.Y + this.movePoint.Y
					);
					this.size.Height = this.Height;
				} else if(this.isBottomSizing) {
					this.Size = new Size(min.Width, ruler.Height + p.Y - this.movePoint.Y);
					this.size.Height = this.Height;
				}
				this.movePoint = p;
				//this.Invalidate();
			} else {
				if(this.Horizontal) {
					if(e.X <= 3 || e.X >= this.Width - 3) {
						this.Cursor = Cursors.SizeWE;
					} else {
						this.Cursor = Cursors.Default;
					}
				} else {
					if(e.Y <= 3 || e.Y >= this.Height - 3) {
						this.Cursor = Cursors.SizeNS;
					} else {
						this.Cursor = Cursors.Default;
					}
				}
			}
		}

		private void Ruler_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
			int step = e.Shift ? 10 : 1;
			if(e.KeyCode == Keys.Left) {
				if(e.Control && this.Horizontal) {
					this.Width -= step;
					this.size.Width = this.Width;
				} else {
					this.Location = new Point(this.Location.X - step, this.Location.Y);
				}
				this.EnsureVisible();
				this.Invalidate();
			} else if(e.KeyCode == Keys.Right) {
				if(e.Control && this.Horizontal) {
					this.Width += step;
					this.size.Width = this.Width;
				} else {
					this.Location = new Point(this.Location.X + step, this.Location.Y);
				}
				this.EnsureVisible();
				this.Invalidate();
			} else if(e.KeyCode == Keys.Up) {
				if(e.Control && !this.Horizontal) {
					this.Height -= step;
					this.size.Height = this.Height;
				} else {
					this.Location = new Point(this.Location.X, this.Location.Y - step);
				}
				this.EnsureVisible();
				this.Invalidate();
			} else if(e.KeyCode == Keys.Down) {
				if(e.Control && !this.Horizontal) {
					this.Height += step;
					this.size.Height = this.Height;
				} else {
					this.Location = new Point(this.Location.X, this.Location.Y + step);
				}
				this.EnsureVisible();
				this.Invalidate();
			}
		}

		//---------------------------------------------------------------------

		private void menuItemFlip_Click(object sender, System.EventArgs e) {
			this.Horizontal = !this.Horizontal;
			this.Invalidate();
		}
		private void menuItemPixel_Click(object sender, System.EventArgs e) {
			this.menuItemPixel.Checked = true;
			this.menuItemInch.Checked = false;
			this.menuItemCentimeter.Checked = false;
			this.Invalidate();
		}
		private void menuItemInch_Click(object sender, System.EventArgs e) {
			this.menuItemPixel.Checked = false;
			this.menuItemInch.Checked = true;
			this.menuItemCentimeter.Checked = false;
			this.Invalidate();
		}
		private void menuItemCentimeter_Click(object sender, System.EventArgs e) {
			this.menuItemPixel.Checked = false;
			this.menuItemInch.Checked = false;
			this.menuItemCentimeter.Checked = true;
			this.Invalidate();
		}
		private void menuItemAbout_Click(object sender, System.EventArgs e) {
			
		}
		private void menuItemExit_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		//---------------------------------------------------------------------

		private Pen pen;
        private StringFormat format;
		private void Ruler_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {

             pen.Color = Color.Black;
            Brush brush = Brushes.Black;
            

            Graphics g = e.Graphics;
			int scale;
			int step;
			int small;
			int big;
			int number;
			string unit;
			if(this.menuItemPixel.Checked) {
                //step = 5; small = 10; big = 50; number = 100; scale = 1; unit = " Pixels";
                step = 2; small = 5; big = 50; number = 100; scale = 1; unit = " Pixels";

            } else if(this.menuItemInch.Checked) {
				g.PageUnit = GraphicsUnit.Inch;
				g.PageScale = 1f / 12f;
				step = 1;
				small = 2;
				big = 6;
				number = 12;
				scale = 12;
				unit = "\"";
			} else { //Cm.
				g.PageUnit = GraphicsUnit.Millimeter;
				g.PageScale = 1f;
				step = 1;
				small = 5;
				big = 10;
				number = 10;
				scale = 10;
				unit = " Cm.";
			}
			PointF[] point = new PointF[] {
				new PointF(2, 2), new PointF(5, 5), new Point(this.Size), this.Location
			};
			g.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, point);
			float infoDelta = this.Horizontal ? point[0].Y : point[0].X;
			float stroke = this.Horizontal ? point[1].Y : point[1].X;
			int length = (int)(point[2].X + point[2].Y);

			if(!this.Horizontal) {
				g.RotateTransform(90, MatrixOrder.Prepend);
				g.TranslateTransform(point[2].X, 0, MatrixOrder.Append);
			}

			for(int i = 0; i < length; i += step) {
				float d = 1;
				if(i % small == 0) {
					if(i % big == 0) {
						d = 3;
					} else {
						d = 2;
					}
				}
				g.DrawLine(this.pen, i, 0f, i, d * stroke);
				if((i % number) == 0) {
					string text = (i / scale).ToString(CultureInfo.InvariantCulture);
					SizeF size = g.MeasureString(text, this.Font, length, this.format);
					g.DrawString(text, this.Font, brush, i - size.Width / 2, d * stroke, this.format);
				}
			}
			string info = string.Format(CultureInfo.InvariantCulture,
				"X={0} Y={1} Length={2}{3}",
				Math.Round(point[3].X / scale, 1),
				Math.Round(point[3].Y / scale, 1),
				Math.Round((float)(this.Horizontal ? point[2].X : point[2].Y) / scale, 1),
				unit
			);
			SizeF infoSize = g.MeasureString(info, this.Font, length, this.format);
			float y = (float)(this.Horizontal ? point[2].Y : point[2].X);
			g.DrawString(info, this.Font, brush,
				(y - infoSize.Height) / 2, y - infoSize.Height - infoDelta, this.format
			);
		}
	}
}
