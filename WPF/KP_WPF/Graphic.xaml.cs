using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace KP_WPF
{
    /// <summary>
    /// Логика взаимодействия для Graphic.xaml
    /// </summary>
    public partial class Graphic : Window
    {
        const int countDot = 10;
        List<double[]> dataList = new List<double[]>();
        List<double> func = new List<double>();
        DrawingGroup drawingGroup = new DrawingGroup();
        public Graphic()
        {
            InitializeComponent();
            DataFill();
            Execute();
            image1.Source = new DrawingImage(drawingGroup);
        }
        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }
        void DataFill()
        {
            double y = 0;
            for (double i = -4.5; i < 5; i += 0.5)
            {
                func.Add(Math.Abs(Math.Pow(i, 2) - 4 * Math.Abs(i) + 3));
            }
            dataList.Add(func.ToArray());
        }
        void Execute()
        {
            BackgroundFun();
            GridFun();
            Fun();
            MarkerFun();
        }

        private void BackgroundFun()
        {
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            RectangleGeometry rectGeometry = new RectangleGeometry();
            rectGeometry.Rect = new Rect(0, -0.8, 2, 2);
            geometryDrawing.Geometry = rectGeometry;
            geometryDrawing.Pen = new Pen(Brushes.Red, 0.005);
            geometryDrawing.Brush = Brushes.Beige;
            drawingGroup.Children.Add(geometryDrawing);
        }
        private void GridFun()
        {
            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = -8; i < 13; i++)
            {
                LineGeometry line = new LineGeometry(new Point(2, i * 0.1),
                new Point(-0.1, i * 0.1));
                geometryGroup.Children.Add(line);
            }
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;
            geometryDrawing.Pen = new Pen(Brushes.Gray, 0.003);
            double[] dashes = { 1, 1, 1, 1, 1 };
            geometryDrawing.Pen.DashStyle = new DashStyle(dashes, -.1);
            geometryDrawing.Brush = Brushes.Beige;
            drawingGroup.Children.Add(geometryDrawing);
        }
        private void Fun()
        {
            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = 0; i < dataList[0].Length - 1; i++)
            {
                LineGeometry line = new LineGeometry(
                                new Point((double)i / (double)countDot,
                                .8 - (dataList[0][i] / 4.0)),
                                new Point((double)(i + 1) / (double)countDot,
                                .8 - (dataList[0][i + 1] / 4.0)));
                geometryGroup.Children.Add(line);

            }
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;
            geometryDrawing.Pen = new Pen(Brushes.Blue, 0.005);
            drawingGroup.Children.Add(geometryDrawing);
        }
        private void MarkerFun()
        {
            GeometryGroup geometryGroup = new GeometryGroup();

            for (int i = -10; i <= 15; i += 2)
            {
                FormattedText formattedText = new FormattedText((((10 - i) * 0.3).ToString()), CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Verdana"), 0.05, Brushes.Black);
                formattedText.SetFontWeight(FontWeights.Bold);
                Geometry geometry = formattedText.BuildGeometry(new Point(-0.15, i * 0.08));
                geometryGroup.Children.Add(geometry);
            }
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;
            geometryDrawing.Brush = Brushes.LightGray;
            geometryDrawing.Pen = new Pen(Brushes.Gray, 0.003);
            drawingGroup.Children.Add(geometryDrawing);
        }
    }
}
