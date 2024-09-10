using System.Collections.Generic;
using System.Threading.Tasks;

namespace XML_Cleaner.Model;

public class ClearingWorker
{
    // list of elements
    // xml content

    private List<Element> _elements = [];
    // maybe make contract interface for files contents
    //private string _content;

    public ClearingWorker()
    {
        
    }

    public async Task ClearFileAsync()
    {
        await Task.Delay(100);
    }
}

// progress
// may be use count of rows and use relative value => 100 / count = percents value for 1 element
// then should increasing this value to 100%
// https://ru.stackoverflow.com/questions/1214884/%D0%92%D1%8B%D0%B2%D0%BE%D0%B4-%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B5%D1%81%D1%81%D0%B0-%D0%B0%D1%81%D0%B8%D0%BD%D1%85%D1%80%D0%BE%D0%BD%D0%BD%D0%BE%D0%B9-%D0%BE%D0%BF%D0%B5%D1%80%D0%B0%D1%86%D0%B8%D0%B8-%D0%B2%D0%BE-%D0%B2%D1%82%D0%BE%D1%80%D0%B8%D1%87%D0%BD%D0%BE%D0%B5-%D0%BE%D0%BA%D0%BD%D0%BE
// https://stackoverflow.com/questions/48625152/how-is-progresst-different-from-actiont
// https://learn.microsoft.com/ru-ru/dotnet/api/system.progress-1?view=net-8.0
// https://learn.microsoft.com/ru-ru/windows/uwp/launch-resume/monitor-background-task-progress-and-completion