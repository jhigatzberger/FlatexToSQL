using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using FlatexToSQL.DataModels;

namespace FlatexToSQL.ViewModels
{
    public class FlatexActionPlotViewModel
    {
        public FlatexActionPlotViewModel()
        {
            using Context context = new();
            List<FlatexAction> actions = context.GetAllActions();
            actions.Sort((x, y) => DateTime.Compare(x.DateTime, y.DateTime));
            FlatexActionPlot = CreatePlot(actions);
        }
        public PlotModel FlatexActionPlot { get; private set; }
        private static PlotModel CreatePlot(List<FlatexAction> values)
        {
            LineSeries lineSeries = new();
            double total = 0, lastX = 0;
            foreach (FlatexAction value in values)
            {
                double px = DateTimeAxis.ToDouble(value.DateTime);
                total += value.EffectiveValue;
                if (px != lastX)
                {
                    lineSeries.Points.Add(new DataPoint(px, total));
                    lastX = px;
                }
                else
                {
                    lineSeries.Points[^1] = new DataPoint(px, total);
                }
            }
            PlotModel plot = new();
            plot.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = DateTimeAxis.ToDouble(values[0].DateTime),
                Maximum = DateTimeAxis.ToDouble(values[^1].DateTime),
                StringFormat = "dd/MM/yyyy"
            });
            plot.Series.Add(lineSeries);
            return plot;
        }

    }
}
