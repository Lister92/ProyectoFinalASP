using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalASP
{
    public partial class RutaCrear : Page
    {
        List<float[,]> coordsList = new List<float[,]>();

        float coordX;
        float coordY;
        //float coord2X;
        //float coord2Y;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void pBlngHTML_ValueChanged(object sender, EventArgs e)
        {


        }

        protected void pAlatHTML_ValueChanged(object sender, EventArgs e)
        {
            string pAlngCS = pAlngHTML.Value;
            string pAlatCS = pAlatHTML.Value;

            //string pBlngCS = pBlngHTML.Value;
            //string pBlatCS = pBlatHTML.Value;

            if (coordX != 0)
            {

                coordX = float.Parse(pAlngCS);
                coordY = float.Parse(pAlatCS);

                //coord2X = float.Parse(pBlngCS);
                //coord2Y = float.Parse(pBlatCS);


                float[,] coordLinea = { { coordX, coordY } };

                coordsList.Add(coordLinea);
            }
        }

        protected void pAlatHTML_ValueChanged1(object sender, EventArgs e)
        {
            string pAlngCS = pAlngHTML.Value;
            string pAlatCS = pAlatHTML.Value;

            //string pBlngCS = pBlngHTML.Value;
            //string pBlatCS = pBlatHTML.Value;

            if (coordX != 0)
            {

                coordX = float.Parse(pAlngCS);
                coordY = float.Parse(pAlatCS);

                //coord2X = float.Parse(pBlngCS);
                //coord2Y = float.Parse(pBlatCS);


                float[,] coordLinea = { { coordX, coordY } };

                coordsList.Add(coordLinea);

            }
        }
    }
}

//Layer layer = Json.Convert.DeserializeObject<Layer>(jsonString);
//public class Layer {
//public string a { get; set; }