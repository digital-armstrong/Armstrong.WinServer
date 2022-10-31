using System.Data;
using System.Linq;
using System.Windows.Forms;
using NLog;

namespace Armstrong.WinServer
{
    public partial class ChannelBlowoutReport : Form
    {
        static private Logger logger;
        public ChannelBlowoutReport(DataSet dataSet)
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember(
               "DoubleBuffered",
               System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
               null,
               blowoutReportGrid,
               new object[] { true });

            logger = LogManager.GetCurrentClassLogger();
            logger.Debug("Вызвано окно расчета выбросов.");

            blowoutReportGrid.DataSource = dataSet.Tables[0];
            blowoutCategoriesReportGrid.DataSource = dataSet.Tables[1];
            //blowoutRegularReport.DataSource = dataSet.Tables[2];

            blowoutReportGrid.Columns.Cast<DataGridViewColumn>()
                .ToList()
                .ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            blowoutCategoriesReportGrid.Columns.Cast<DataGridViewColumn>()
               .ToList()
               .ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            //blowoutRegularReport.Columns.Cast<DataGridViewColumn>()
            //   .ToList()
            //   .ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }
    }
}
