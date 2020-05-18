using ChustaSoft.Common.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ChustaSoft.GamersPlatformUtils.UI.Helpers
{
    public static class FileInfoMapper
    {

        public static SelectableOption<FileInfo> Map(FileInfo source)
        {
            return new SelectableOption<FileInfo>
            {
                Name = source.FullName,
                Value = source,
                Selected = true
            };

        }

        public static ObservableCollection<SelectableOption<FileInfo>> Map(this IEnumerable<FileInfo> source)
            => new ObservableCollection<SelectableOption<FileInfo>>(source.Select(Map));

    }
}
