using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public partial class DataModelDataSet
    {
        // Statisks konstruktors tiek izsaukts, tikai kad klasei veido pirmo objektu
        static DataModelDataSet()
        {
            // Ja nenotiek palaišana no izstrādes vides, tad neko nemaina:
            if (!System.Diagnostics.Debugger.IsAttached)
                return;
            // Noskaidro tekošā kataloga ceļu:
            string dir = System.Environment.CurrentDirectory;

            // No tekošā ceļa atmet pēdējos trīs katalogus "\<projekts>\bin\Debug":
            for (int n = 3; n > 0; n--)
                dir = dir.Substring(0, dir.LastIndexOf('\\'));
            // Pievieno projekta DataModel asamblejas katalogu:
            dir = System.IO.Path.Combine(dir
            , System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            // Aktualizē iebūvēto uzstādījumu |DataDirectory|, kas tiek lietota
            // pieslēguma virknē QualificationWorksConnectionString:
            AppDomain.CurrentDomain.SetData("DataDirectory", dir);
        }
    }
}
