using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Desenho
{
    class Cordenadas
    {
        public Cordenadas(Pen pen, Point x, Point y)
        {
            this.pen = pen;
            this.x = x;
            this.y = y;
        }
        public Point x;
        public Point y;
        public Pen pen;
    }
}
