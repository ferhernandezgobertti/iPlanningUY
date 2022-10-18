using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class SolidGrid : Grid
    {

        public override void Draw(ref Graphics graphUsed, Chart chartOnWhichToDraw)
        {
            Point[] drawLimits = new Point[2];
            Pen lineFormat = new Pen(Color.Black, 2);
            int pixelsChecked;
            for (pixelsChecked = 0; pixelsChecked < chartOnWhichToDraw.GetPixels()[0] + ConstantsChart.BLOCKPIXELS; pixelsChecked += 50)
            {
                Point origin = new Point(ConstantsChart.BLOCKPIXELS + pixelsChecked, ConstantsChart.BLOCKPIXELS);
                Point destination = new Point(ConstantsChart.BLOCKPIXELS + pixelsChecked, ConstantsChart.BLOCKPIXELS + chartOnWhichToDraw.GetPixels()[1]);
                drawLimits = new Point[] { origin, destination };
                graphUsed.DrawLine(lineFormat, drawLimits[0].X, drawLimits[0].Y, drawLimits[1].X, drawLimits[1].Y);
            }

            for (pixelsChecked = 0; pixelsChecked < chartOnWhichToDraw.GetPixels()[1] + ConstantsChart.BLOCKPIXELS; pixelsChecked += 50)
            {
                Point origin = new Point(ConstantsChart.BLOCKPIXELS, ConstantsChart.BLOCKPIXELS + pixelsChecked);
                Point destination = new Point(ConstantsChart.BLOCKPIXELS + chartOnWhichToDraw.GetPixels()[0], ConstantsChart.BLOCKPIXELS + pixelsChecked);
                drawLimits = new Point[] { origin, destination };
                graphUsed.DrawLine(lineFormat, drawLimits[0].X, drawLimits[0].Y, drawLimits[1].X, drawLimits[1].Y);
            }
        }

    }
}
