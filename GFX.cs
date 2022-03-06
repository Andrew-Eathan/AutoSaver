using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOverlay.Drawing;
using GameOverlay.Windows;

namespace autosaver
{
    class GFX
    {
        public GraphicsWindow window;

        private readonly Dictionary<string, SolidBrush> brushes;
        private readonly Dictionary<string, Font> fonts;
        private readonly Dictionary<string, Image> images;

		public string toptext;
		public bool active = false;
		public string bottomtext;

		public GFX()
		{
			brushes = new Dictionary<string, SolidBrush>();
			fonts = new Dictionary<string, Font>();
			images = new Dictionary<string, Image>();

			var gfx = new Graphics()
			{
				MeasureFPS = true,
				PerPrimitiveAntiAliasing = true,
				TextAntiAliasing = true
			};

			window = new GraphicsWindow(10, 10, 400, 110, gfx)
			{
				FPS = 20,
				IsTopmost = true,
				IsVisible = true
			};

			window.DestroyGraphics += window_DestroyGraphics;
			window.DrawGraphics += window_DrawGraphics;
			window.SetupGraphics += window_SetupGraphics;
		}

		private void window_SetupGraphics(object sender, SetupGraphicsEventArgs e)
		{
			var gfx = e.Graphics;

			if (e.RecreateResources)
			{
				foreach (var pair in brushes) pair.Value.Dispose();
				foreach (var pair in images) pair.Value.Dispose();
			}

			brushes["black"] = gfx.CreateSolidBrush(0, 0, 0);
			brushes["white"] = gfx.CreateSolidBrush(255, 255, 255);
			brushes["red"] = gfx.CreateSolidBrush(255, 0, 0);
			brushes["green"] = gfx.CreateSolidBrush(0, 255, 0);
			brushes["blue"] = gfx.CreateSolidBrush(0, 0, 255);
			brushes["background"] = gfx.CreateSolidBrush(40, 10, 50, 0.8f);
			brushes["alpha"] = gfx.CreateSolidBrush(0, 0, 0, 0);
			brushes["grid"] = gfx.CreateSolidBrush(255, 255, 255, 0.2f);
			brushes["random"] = gfx.CreateSolidBrush(0, 0, 0);

			if (e.RecreateResources) return;

			images["save"] = gfx.CreateImage(Properties.Resources.save1);
			fonts["consolas"] = gfx.CreateFont("Consolas", 14);
			fonts["consolasbig"] = gfx.CreateFont("Consolas", 16, true);
		}

		private void window_DestroyGraphics(object sender, DestroyGraphicsEventArgs e)
		{
			foreach (var pair in brushes) pair.Value.Dispose();
			foreach (var pair in fonts) pair.Value.Dispose();
			foreach (var pair in images) pair.Value.Dispose();
		}

		Point ip = new Point(10, 10);
		Point asp = new Point(30, 10);
		Point ttp = new Point(10, 30);
		Point stp = new Point(10, 50);

		private void window_DrawGraphics(object sender, DrawGraphicsEventArgs e)
		{
			var gfx = e.Graphics;
			gfx.ClearScene(brushes["alpha"]);

			if (!active) return;
			gfx.OutlineFillRectangle(brushes["white"], brushes["background"], new Rectangle(0, 0, 400, window.Height), 1);

			gfx.DrawImage(images["save"], ip, 1);
			gfx.DrawText(fonts["consolasbig"], brushes["white"], asp, "AutoSaver");
			gfx.DrawText(fonts["consolas"], brushes["white"], ttp, toptext);
			gfx.DrawText(fonts["consolas"], brushes["white"], stp, bottomtext);
		}

		public void Run()
		{
			window.Create();
			window.Join();
		}

		~GFX()
		{
			Dispose(false);
		}

		#region IDisposable Support
		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				window.Dispose();
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
