using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGalery.Models;
internal class Category
{
    public string Name { get; set; }
    public List<Component> Components { get; set; } //lista da classe component
}
