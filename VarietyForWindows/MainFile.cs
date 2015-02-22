using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VarietyForWindows.Properties;
using System.Collections;
using System.IO;
using System.Threading;
using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Filters.EdgeDetection;
using ImageProcessor.Imaging.Filters.Photo;
using ImageProcessor.Imaging.Formats;
//using ImageProcessor.Imaging.Formats;


namespace VarietyForWindows
{
	public partial class MainFile : Form
    {
		int value = 10000;
		int opacity = 70;
        int fontsize = 50;
		int xpos = 300;
		int ypos = 700;
		bool shadow = false;
		string[] quotes = new string[3] {"You learn to speak by speaking, to study by studying, to run by running, to work by working. In just the same way, you learn to love by loving.","I love you, and because I love you, I would sooner have you hate me for telling you the truth than adore me for telling you lies.","There are people who are very resourceful, at being remorseful, and who apparently feel that the best way to make friends is to do something terrible and then make amends"};
		Dictionary<string, int> Frequency = new Dictionary<string, int>()
	{{"10 seconds", 10000 },{"20 seconds", 20000 },{"30 seconds", 30000 },{"40 seconds", 40000 },{"50 seconds", 50000 },{"1 minutes", 60000 },{"2 minutes", 120000 },{"5 minutes", 300000 }};
		public MainFile()
		{
			InitializeComponent();    
		}
		

		List<string> Filenames = new List<string>();
		public string[] filenamestring = null;

		private void tabPage2_Click(object sender, EventArgs e)
		{

		}

		private void tabPage4_Click(object sender, EventArgs e)
		{

		}

		private void Add_Click(object sender, EventArgs e)
		{
			this.folderBrowserDialog1.RootFolder=System.Environment.SpecialFolder.MyComputer;
			this.folderBrowserDialog1.ShowNewFolderButton=false;
			DialogResult result=this.folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				// retrieve the name of the selected folder
				string foldername = this.folderBrowserDialog1.SelectedPath;
				string[] temp = foldername.Split(new Char[] { '\\'});
				this.Use_Add_button.Items.Add(temp.Last());
				// iterate over all files in the selected folder and add them to 
				// the listbox.
				foreach (string filename in Directory.GetFiles(foldername))
					this.Filenames.Add(filename);
			}
		}

		private void Start_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
			restart:
			foreach (string filename in Filenames)
			{
				byte[] photoBytes = File.ReadAllBytes(filename);
				ISupportedImageFormat format = new JpegFormat();
				using (MemoryStream inStream = new MemoryStream(photoBytes))
				{
					string[] temp = filename.Split(new Char[] { '\\'});
					string tempe = temp.Last();
					string outputFileName = string.Format("E:\\res\\{0}", tempe);
					string quote = quotes[new Random().Next(0, quotes.Length)];
					using (MemoryStream outStream = new MemoryStream())
					{
						// Initialize the ImageFactory using the overload to preserve EXIF metadata.
						using (ImageFactory imageFactory = new ImageFactory())
						{
							// Load, resize, set the format and quality and save an image.
							if (BlackWhite.Checked)
							{
								IMatrixFilter filter = MatrixFilters.BlackWhite;
								imageFactory.Load(inStream);
								imageFactory.Filter(filter);
								imageFactory.Format(format);
								imageFactory.Watermark(new TextLayer
								{
									FontFamily = new FontFamily("Arial"),
									FontSize = this.fontsize,
									Position = new Point(xpos, ypos),
									Opacity = opacity,
									DropShadow = shadow,
									Text = quote
								});
								imageFactory.Save(outputFileName);
								wallpaper.SetDesktopWallpaper(outputFileName);
							}
							else if (Comic.Checked)
							{
								IMatrixFilter filter = MatrixFilters.Comic;
								imageFactory.Load(inStream);
								imageFactory.Filter(filter);
								imageFactory.Format(format);
								imageFactory.Watermark(new TextLayer
								{
									FontFamily = new FontFamily("Arial"),
									FontSize = fontsize,
									Position = new Point(xpos, ypos),
									Opacity = opacity,
									DropShadow = shadow,
									Text = quote
								});
								imageFactory.Save(outputFileName);
								wallpaper.SetDesktopWallpaper(outputFileName);
							}
							else if (HiSatch.Checked)
							{
								IMatrixFilter filter = MatrixFilters.HiSatch;
								imageFactory.Load(inStream);
								imageFactory.Filter(filter);
								imageFactory.Format(format);
								imageFactory.Watermark(new TextLayer
								{
									FontFamily = new FontFamily("Arial"),
									FontSize = this.fontsize,
									Position = new Point(xpos, ypos),
									Opacity = opacity,
									DropShadow = shadow,
									Text = quote
								});
								imageFactory.Save(outputFileName);
								wallpaper.SetDesktopWallpaper(outputFileName);
							}
							else if (LoSatch.Checked)
							{
								IMatrixFilter filter = MatrixFilters.LoSatch;
								imageFactory.Load(inStream);
								imageFactory.Filter(filter);
								imageFactory.Format(format);
								imageFactory.Watermark(new TextLayer
								{
									FontFamily = new FontFamily("Arial"),
									FontSize = fontsize,
									Position = new Point(xpos, ypos),
									Opacity = opacity,
									DropShadow = shadow,
									Text = quote
								});
								imageFactory.Save(outputFileName);
								wallpaper.SetDesktopWallpaper(outputFileName);
							}
							else if (Polaroid.Checked)
							{
								IMatrixFilter filter = MatrixFilters.Polaroid;
								imageFactory.Load(inStream);
								imageFactory.Filter(filter);
								imageFactory.Format(format);
								imageFactory.Watermark(new TextLayer
								{
									FontFamily = new FontFamily("Arial"),
									FontSize = fontsize,
									Position = new Point(xpos, ypos),
									Opacity = opacity,
									DropShadow = shadow,
									Text = quote
								});
								imageFactory.Save(outputFileName);
								wallpaper.SetDesktopWallpaper(outputFileName);
							}
							else if (GreyScale.Checked)
							{
								IMatrixFilter filter = MatrixFilters.GreyScale;
								imageFactory.Load(inStream);
								imageFactory.Filter(filter);
								imageFactory.Format(format);
								imageFactory.Watermark(new TextLayer
								{
									FontFamily = new FontFamily("Arial"),
									FontSize = fontsize,
									Position = new Point(xpos, ypos),
									Opacity = opacity,
									DropShadow = shadow,
									Text = quote
								});
								imageFactory.Save(outputFileName);
								wallpaper.SetDesktopWallpaper(outputFileName);
							}
							else if (Gotham.Checked)
							{
								IMatrixFilter filter = MatrixFilters.Gotham;
								imageFactory.Load(inStream);
								imageFactory.Filter(filter);
								imageFactory.Format(format);
								imageFactory.Watermark(new TextLayer
								{
									FontFamily = new FontFamily("Arial"),
									FontSize = fontsize,
									Position = new Point(xpos, ypos),
									Opacity = opacity,
									DropShadow = shadow,
									Text = quote
								});
								imageFactory.Save(outputFileName);
								wallpaper.SetDesktopWallpaper(outputFileName);
							}
							else if (Sepia.Checked)
							{
								IMatrixFilter filter = MatrixFilters.Sepia;
								imageFactory.Load(inStream);
								imageFactory.Filter(filter);
								imageFactory.Format(format);
								imageFactory.Watermark(new TextLayer
								{
									FontFamily = new FontFamily("Arial"),
									FontSize = fontsize,
									Position = new Point(xpos,ypos),
									Opacity = opacity,
									DropShadow = shadow,
									Text = quote
								});
								imageFactory.Save(outputFileName);
								wallpaper.SetDesktopWallpaper(outputFileName);
							}


						}
						// Do something with the stream.
 
					}
				}
				//wallpaper.SetDesktopWallpaper(filename);
				Thread.Sleep(value);
				if (Filenames.Last() == filename)
				{
					goto restart;
				}
			}
		}

		private void frequencies_SelectedIndexChanged(object sender, EventArgs e)
		{
			string var = frequencies.Text;
			Frequency.TryGetValue(var,out value);  // this value supplied sleep
		}

		


	}
}
