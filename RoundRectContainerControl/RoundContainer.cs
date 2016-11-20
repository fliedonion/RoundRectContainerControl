using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Case_of_t.net.WinForms.Controls.RoundRectContainerControl {

    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    [System.ComponentModel.DesignerCategory("Code")]
    public partial class RoundRectContainer : UserControl {
        public RoundRectContainer() {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ContainerControl, true);
            base.BackColor = Color.Transparent;
        }

        private int borderWidth = 1;
        private int dropShadowOffset = 4;
        private DropShadowDirections dropShadowDirection = DropShadowDirections.BottomRight;
        private Color borderColor = SystemColors.ActiveBorder;
        private Color borderFillColor = Color.Transparent;
        private Color dropShadowColor = SystemColors.ActiveBorder;

        protected const int MaxRaduis = 500;
        protected int cornerRadius = 4;

        private bool topLeft = true;
        private bool topRight = true;
        private bool bottomRight = true;
        private bool bottomLeft = true;




        public enum DropShadowDirections {
            None = 0,
            TopLeft = 1,
            TopRight = 2,
            BottomRight = 4,
            BottomLeft = 8,
        }

        [Category("Appearance")]
        [DefaultValue(4)]
        public int DropShadowOffset {
            get { return dropShadowOffset; }
            set {
                dropShadowOffset = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("現在は右下のみサポートしています。This version only supports BottomRight")]
        [DefaultValue(DropShadowDirections.BottomRight)]
        public DropShadowDirections DropShadowDirection {
            get { return dropShadowDirection; }
            set {
                dropShadowDirection = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderFillColor {
            get { return borderFillColor; }
            set {
                borderFillColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color DropShadowColor {
            get { return dropShadowColor; }
            set {
                dropShadowColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool CornerRoundTopLeft {
            get { return topLeft; }
            set {
                topLeft = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool CornerRoundTopRight {
            get { return topRight; }
            set {
                topRight = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool CornerRoundBottomRight {
            get { return bottomRight; }
            set {
                bottomRight = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool CornerRoundBottomLeft {
            get { return bottomLeft; }
            set {
                bottomLeft = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public int BorderWidth {
            get { return borderWidth; }
            set {
                borderWidth = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderColor {
            get { return borderColor; }
            set {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public int CornerRadius {
            get { return cornerRadius; }
            set {
                var shadowSize = dropShadowOffset;
                if (dropShadowColor == Color.Transparent || dropShadowDirection == DropShadowDirections.None) {
                    shadowSize = 0;
                }

                var max = (Width > Height ? Height + shadowSize : Width + shadowSize) / 3;
                cornerRadius = value > max ? max : value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor {
            get { return base.BackColor; }
            set { base.BackColor = Color.Transparent; } 
        }


        protected override void OnSizeChanged(EventArgs e) {
            CornerRadius = cornerRadius;
            base.OnSizeChanged(e);
        }

        protected override void OnClientSizeChanged(EventArgs e) {
            CornerRadius = cornerRadius;
            base.OnClientSizeChanged(e);
        }


        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            var baseRect = new Rectangle(
                BorderWidth + Padding.Left,
                BorderWidth + Padding.Top,
                Width - BorderWidth * 2 - (Padding.Right + Padding.Left),
                Height - BorderWidth * 2 - (Padding.Bottom + Padding.Top));

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            DrawDropShadow(e.Graphics, baseRect);
            DrawBorderRect(e.Graphics, baseRect);
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            base.OnPaintBackground(e);
        }

        protected virtual void DrawDropShadow(Graphics g, Rectangle rect) {

            if(DropShadowDirection == DropShadowDirections.None) return;
            if (DropShadowColor == Color.Transparent) return;

            rect.Size = new Size(rect.Size.Width - dropShadowOffset, rect.Size.Height - dropShadowOffset);
            switch (DropShadowDirection) {
                case DropShadowDirections.BottomLeft:
                    rect.Location = new Point(rect.X, rect.Y + DropShadowOffset);
                    break;
                case DropShadowDirections.BottomRight:
                    rect.Location = new Point(rect.X + DropShadowOffset, rect.Y + DropShadowOffset);
                    break;
                case DropShadowDirections.TopLeft:
                    rect.Location = new Point(rect.X, rect.Y);
                    break;
                case DropShadowDirections.TopRight:
                    rect.Location = new Point(rect.X + DropShadowOffset, rect.Y);
                    break;
            }

            var oldCompMode = g.CompositingMode;
            g.CompositingMode = CompositingMode.SourceOver;

            using (var path = RectToGraphicPath(rect, topLeft, topRight, bottomRight, bottomLeft)) {
                if (DropShadowColor != Color.Transparent) {
                    if (BorderFillColor != Color.Transparent) {
                        using (var brush = new SolidBrush(DropShadowColor)) {
                            g.FillPath(brush, path);
                        }
                    }
                    else {
                        using (var pen = new Pen(Color.FromArgb(128, DropShadowColor), BorderWidth)) {
                            g.DrawPath(pen, path);
                        }
                    }
                }
            }
            g.CompositingMode =oldCompMode;
        }

        protected virtual void DrawBorderRect(Graphics g, Rectangle rect) {

            if (DropShadowDirection != DropShadowDirections.None) {
                rect.Size = new Size(rect.Size.Width - dropShadowOffset, rect.Size.Height - dropShadowOffset);

                switch (DropShadowDirection) {
                    case DropShadowDirections.BottomLeft:
                        rect.Location = new Point(rect.X + DropShadowOffset, rect.Y);
                        break;
                    case DropShadowDirections.BottomRight:
                        rect.Location = new Point(rect.X, rect.Y);
                        break;
                    case DropShadowDirections.TopLeft:
                        rect.Location = new Point(rect.X + DropShadowOffset, rect.Y + DropShadowOffset);
                        break;
                    case DropShadowDirections.TopRight:
                        rect.Location = new Point(rect.X, rect.Y + DropShadowOffset);
                        break;
                }
            }

            using (var path = RectToGraphicPath(rect, topLeft, topRight, bottomRight, bottomLeft)) {

                if (BorderFillColor != Color.Transparent) {
                    using(var brush = new SolidBrush(BorderFillColor)){
                        g.FillPath(brush, path);    
                    }
                }

                using(var pen = new Pen(BorderColor, BorderWidth))
                g.DrawPath(pen, path);

            }

        }

        protected GraphicsPath RectToGraphicPath(Rectangle rect, bool topLeft, bool topRight, bool bottomRight, bool bottomLeft) {
            var round = CornerRadius * 2;
            var path = new GraphicsPath();

            int lt = topLeft ? round : 0;
            int rt = topRight ? round : 0;
            int rb = bottomRight ? round : 0;
            int lb = bottomLeft ? round : 0;


            path.AddLine(rect.Left + lt, rect.Top, rect.Right - rt, rect.Top);
            if(rt > 0) path.AddArc(Rectangle.FromLTRB(rect.Right - rt, rect.Top, rect.Right, rect.Top + rt), -90, 90);

            path.AddLine(rect.Right, rect.Top + rt, rect.Right, rect.Bottom - rb);
            if(rb > 0) path.AddArc(Rectangle.FromLTRB(rect.Right - rb, rect.Bottom - rb, rect.Right, rect.Bottom), 0, 90);

            path.AddLine(rect.Right - rb, rect.Bottom, rect.Left + lb, rect.Bottom);
            if(lb > 0) path.AddArc(Rectangle.FromLTRB(rect.Left, rect.Bottom - lb, rect.Left + lb, rect.Bottom), 90, 90);

            path.AddLine(rect.Left, rect.Bottom - lb, rect.Left, rect.Top + lt);
            if(lt > 0) path.AddArc(Rectangle.FromLTRB(rect.Left, rect.Top, rect.Left + lt, rect.Top + lt), 180, 90);

            path.CloseFigure();

            return path;
        }

    }
}
