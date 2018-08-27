using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Synthexer.UI
{
	[Designer(typeof(SeparatorDesigner))]
	public class Separator : UserControl
	{

		public enum LineOrientation
		{
			Horizontal,
			Vertical
		}

		public Separator()
		{
			InitializeComponent();
			this.Height = 2;
		}

		private void InitializeComponent()
		{
		}

		private Color _Color1 = SystemColors.ControlDark;
		[DefaultValue(typeof(Color), "ControlDark")]
		public Color Color1
		{
			get { return _Color1; }
			set { _Color1 = value; }
		}

		private Color _Color2 = Color.White;
		[DefaultValue(typeof(Color), "White")]
		public Color Color2
		{
			get { return _Color2; }
			set { _Color2 = value; }
		}

		private LineOrientation _Orientation = LineOrientation.Horizontal;
		[DefaultValue(LineOrientation.Horizontal)]
		public LineOrientation Orientation
		{
			get { return _Orientation; }
			set
			{
				_Orientation = value;

				//Swap width and height
				if (value == LineOrientation.Horizontal)
				{
					this.Width = this.Height;
					this.Height = 2;
				}
				else
				{
					this.Height = this.Width;
					this.Width = 2;
				}
			}
		}

		protected override void OnResize(System.EventArgs e)
		{
			base.OnResize(e);
			if (this.Orientation == LineOrientation.Horizontal)
			{
				this.Height = 2;
			}
			else
			{
				this.Width = 2;
			}
		}

		protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			if (this.Orientation == LineOrientation.Horizontal)
			{
				e.Graphics.DrawLine(new Pen(this.Color1), 0, 0, this.Width, 0);
				e.Graphics.DrawLine(new Pen(this.Color2), 0, 1, this.Width, 1);
			}
			else
			{
				e.Graphics.DrawLine(new Pen(this.Color1), 0, 0, 0, this.Height);
				e.Graphics.DrawLine(new Pen(this.Color2), 1, 0, 1, this.Height);
			}
		}

	}

	public class SeparatorDesigner : System.Windows.Forms.Design.ControlDesigner
	{


		private DesignerActionListCollection lists;
		//Retrieves the Separator control to which this designer belongs
		private Separator HostControl
		{
			get { return (Separator)this.Control; }
		}

		//Adds the Action Lists (> menu) 
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				if (lists == null)
				{
					lists = new DesignerActionListCollection();
					lists.Add(new SeparatorActionList(this.Component));
				}
				return lists;
			}
		}

		//Allows only horizontal/vertical resizing
		public override System.Windows.Forms.Design.SelectionRules SelectionRules
		{
			get
			{
				SelectionRules selRules = System.Windows.Forms.Design.SelectionRules.Moveable;

				if (this.HostControl.Orientation == Separator.LineOrientation.Horizontal)
				{
					selRules = selRules | System.Windows.Forms.Design.SelectionRules.LeftSizeable | System.Windows.Forms.Design.SelectionRules.RightSizeable;
				}
				else
				{
					selRules = selRules | System.Windows.Forms.Design.SelectionRules.TopSizeable | System.Windows.Forms.Design.SelectionRules.BottomSizeable;
				}

				return selRules;
			}
		}

		protected override void PostFilterProperties(System.Collections.IDictionary properties)
		{
			properties.Remove("BackColor");
			properties.Remove("BackgroundImage");
			properties.Remove("BackgroundImageLayout");
			properties.Remove("BorderStyle");
			properties.Remove("Font");
			properties.Remove("ForeColor");
			properties.Remove("RightToLeft");
			base.PostFilterProperties(properties);
		}

		//The class that shows the Action List (> menu) properties
		public class SeparatorActionList : DesignerActionList
		{

			private Separator _sep;

			private DesignerActionUIService designerActionSvc = null;
			public SeparatorActionList(IComponent component)
				: base(component)
			{
				_sep = (Separator)component;

				this.designerActionSvc = (DesignerActionUIService)GetService(typeof(DesignerActionUIService));
			}

			public Color Color1
			{
				get { return _sep.Color1; }
				set { _sep.Color1 = value; }
			}

			public Color Color2
			{
				get { return _sep.Color2; }
				set { _sep.Color2 = value; }
			}

			public Separator.LineOrientation Orientation
			{
				get { return _sep.Orientation; }
				set { _sep.Orientation = value; }
			}

			public void SwapColors()
			{
				Color c = _sep.Color1;
				_sep.Color1 = _sep.Color2;
				_sep.Color2 = c;
				designerActionSvc.Refresh(_sep);
			}

			public override System.ComponentModel.Design.DesignerActionItemCollection GetSortedActionItems()
			{
				DesignerActionItemCollection items = new DesignerActionItemCollection();

				items.Add(new DesignerActionHeaderItem("Properties"));
				items.Add(new DesignerActionPropertyItem("Color1", "Color1:", "Properties", "The top/left color."));
				items.Add(new DesignerActionPropertyItem("Color2", "Color2:", "Properties", "The bottom/right color."));
				items.Add(new DesignerActionPropertyItem("Orientation", "Orientation:", "Properties", "The orientation of the separator."));
				items.Add(new DesignerActionMethodItem(this, "SwapColors", "Swap colors", "Properties", "Swaps the two colors.", true));

				return (items);
			}
		}

	}
}
