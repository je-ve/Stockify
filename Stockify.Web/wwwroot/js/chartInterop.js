window.chartInterop = {
    drawBarChart: function (chartId, chartData, chartOptions) {
        google.charts.load('current', { 'packages': ['bar'] });
        google.charts.setOnLoadCallback(function () {
            var data = google.visualization.arrayToDataTable(chartData);

            var options = chartOptions || {
                chart: {
                    title: 'Company Performance',
                    subtitle: 'Sales, Expenses, and Profit: 2014-2017',
                },
                bars: 'horizontal' // Required for Material Bar Chart
            };

            var chart = new google.charts.Bar(document.getElementById(chartId));
            chart.draw(data, google.charts.Bar.convertOptions(options));
        });
    }
};