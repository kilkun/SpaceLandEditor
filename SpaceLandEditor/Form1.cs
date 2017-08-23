using System;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Windows.Forms;

namespace SpaceLandEditor
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }
        
        
        //mr. worldwide
        int mapsize { get; set; }
        int bgtile { get; set; }

        string filename;
        string tilesetdir = "E:\\spaceland\\--wu--\\tiles\\";
        string actionclassmap { get; set; }
        string actionmap { get; set; }
        string tilemap { get; set; }
        string firstrow { get; set; }
        string tileset { get; set; }
        string qwikedit { get; set; }
        
        
        string defaultvalue { get; set; }

        string[] actionclassmaparray = new string[256];
        string[] tilemaparray = new string[256];
        string[] actionmaparray = new string[256];
        
        
        
        
        //our map variable stuff
        XmlDocument mapfile = new XmlDocument();
        


        //Open map
        public void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            

            if (file.ShowDialog().Equals(DialogResult.OK))
            {
                
                filename = file.FileName;
                mapfile.Load(filename);
                //acmap
                XmlNodeList actionclassmaps = mapfile.GetElementsByTagName("actionClassMap");
                actionclassmap = actionclassmaps[0].InnerText;
                //amap
                XmlNodeList actionmaps = mapfile.GetElementsByTagName("actionMap");
                actionmap = actionmaps[0].InnerText;
                //tmap
                XmlNodeList tilemaps = mapfile.GetElementsByTagName("tileMap");
                tilemap = tilemaps[0].InnerText;
                XmlNodeList mapinfotemp = mapfile.GetElementsByTagName("info");
                XmlNode mapinfo;
                mapinfo = mapinfotemp.Item(0);
                tileset = mapinfo.Attributes[0].Value;


                bgtile = Convert.ToInt32(mapinfo.Attributes[1].Value);


                actionclassmaparray = scst(actionclassmap);
                tilemaparray = scst2(tilemap);
                actionmaparray = scst2(actionmap);
                qwikedit = "off";



                foreach (XmlNode child in mapfile)
                {
                    if(child.Attributes != null)
                    {//messy shit, but it works.
                        var fakemapsize = child.Attributes["mapSize"];
                        mapsize = Convert.ToInt32(fakemapsize.Value);
                    }
                }
                tilesetdir = tilesetdir + tileset + "\\";




                for (int i = 0; i < mapsize; i++)
                {
                    for(int j = 0; j < mapsize; j++)
                    {
                        Button butt = new Button();
                        this.Controls.Add(butt);
                        butt.Name = i.ToString() + " " +j.ToString();//coords
                        butt.Location = new Point(2 + i * 20, 26 + j * 20);
                        butt.Size = new Size(20, 20);
                        butt.Tag = i;
                        butt.Image = Image.FromFile(tilegraphic(butt.Name));
                        butt.Click += (s, ev) => {
                            if (qwikedit == "off")
                            {
                                edittile(butt.Name);

                            }
                            else if(qwikedit == "ac")
                            {
                                setac(butt.Name);
                            }
                            else if(qwikedit == "t")
                            {
                                sett(butt.Name);
                                
                            }
                            butt.Image = Image.FromFile(tilegraphic(butt.Name));

                        };
                    }
                    
                }
                
                
                

            }
        }
        //don't touch this harvey



        //useless shit
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(
                "Version v1\n"+
                "By Cuttlefish.\n\n\n"+
                "Compatible with Wasteland maps decompiled by WLSuite.");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Butt_Click(object sender, EventArgs e)
        {
            
        }


        //divides strings into rows, stores in array, returns the array
        public string[] scst(string str)
        {
            //clean the string
            str = str.Remove(0,1);//gets rid of the first newline char this is now a part of our code forever for some fucking reason?
            string[] maparray = str.Split(new string[] { "\n" }, StringSplitOptions.None);

            return maparray;

        }

        public string[] scst2(string str)
        {
            string[] maparray = str.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);


            return maparray;
        }









        public int[] dualchar(int coord)
        {

            int[] coords = new int[2];
            coord++;
            coord = coord * 3;

            coords[0] = coord - 2;
            coords[1] = coord - 1;


            return coords;
        }
        public string tilegraphic(string coord)
        {
            string tile = null;
            int numberofzeros = 0;
            int[] xcoords = new int[2];
            //seperates coordinates
            string[] list = coord.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            int x = Convert.ToInt32(list[0]);
            int y = Convert.ToInt32(list[1]) + 1;

            xcoords = dualchar(x);

            int x1 = xcoords[0] - 1;
            int x2 = xcoords[1] - 1;
            string tilerow = tilemaparray[y];



            //locates position in the tilemap array

            string number;
            number = tilerow[x1 + 4].ToString() + tilerow[x2 + 4].ToString();
            if (number == "..") { number = "00"; }

            //convert into int32
            
            int sprite = Convert.ToInt32(number, 16);

            //if the tile is set to one of the masks, we have to tell the program that
            if (sprite > 9)
            {

                sprite -= 10;

                if (sprite < 100)
                {
                    numberofzeros++;
                    if (sprite < 10)
                    {
                        numberofzeros++;
                    }

                }

            }
            else
            {
                tilesetdir = "E:\\spaceland\\--wu--\\sprites\\";
                numberofzeros = 2;
            }

            tile = String.Concat(Enumerable.Repeat("0", numberofzeros)) + sprite.ToString();
            //add ".png" onto the end
            tile = tile + ".png";
            //add that onto the tileset dir string
            tile = tilesetdir + tile;
            
            //reset our tileset dir if it's not one of the first 10
            tilesetdir = "E:\\spaceland\\--wu--\\tiles\\" + tileset + "\\";

            //set tile to equal the result
            return tile;
        }


        //edit the tile
        public void edittile(string coords)
        {
            using (Form2 window = new Form2())
            {
                string[] information = tiledata(coords);
                //pass tile information to new form
                window.actionclass = information[1];
                window.actionnumber = information[2];
                window.tile = information[3];
                window.click();

                if (window.ShowDialog() == DialogResult.OK)
                {
                    information[1] = window.actionclass;
                    information[2] = window.actionnumber;
                    information[3] = window.tile;
                    pushchanges(information, coords);
                    window.Close();

                }


            }

        }






        //qwik edit functions
        
        //action class
        public void setac(string coords)
        {
            int x;
            int y;
            string[] list = new string[2];

            list = coords.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            x = Convert.ToInt32(list[0]);
            y = Convert.ToInt32(list[1]) + 1;

            string acrow = actionclassmaparray[y].Remove(0, 4);
            char[] acarray = acrow.ToArray();
            acarray[x] = Convert.ToChar(defaultvalue);
            acrow = new string(acarray);
            actionclassmaparray[y] = "    " + acrow;


        }
        //tile
        public void sett(string coords)
        {

            int x;
            int y;
            string[] list = new string[2];

            list = coords.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            x = Convert.ToInt32(list[0]);
            y = Convert.ToInt32(list[1]) + 1;
            int[] xcoords = dualchar(x);

            int x1 = xcoords[0] - 1;
            int x2 = xcoords[1] - 1;

            string trow = tilemaparray[y].Remove(0, 4);
            char[] tarray = trow.ToArray();


            tarray[x1] = Convert.ToChar(defaultvalue[0]);
            tarray[x2] = Convert.ToChar(defaultvalue[1]);
            trow = new string(tarray);
            tilemaparray[y] = "    " + trow;
        }
        


        //save to loaded strings
        public void pushchanges(string[] info, string coords)
        {
            string[] list = new string[2];
            int x;
            int y;

            list = coords.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            x = Convert.ToInt32(list[0]);
            y = Convert.ToInt32(list[1]) + 1;

            int[] xcoords = dualchar(x);

            int x1 = xcoords[0] - 1;
            int x2 = xcoords[1] - 1;



            //acmap operations
            string acrow = actionclassmaparray[y].Remove(0, 4);
            char[] acarray = acrow.ToArray();
            acarray[x] = Convert.ToChar(info[1]);
            acrow = new string(acarray);
            actionclassmaparray[y] = "    " + acrow;

            //amap operations
            string arow = actionmaparray[y].Remove(0, 4);
            char[] a_array = arow.ToArray();
            string number = info[2];
            a_array[x1] = Convert.ToChar(number[0]);
            a_array[x2] = Convert.ToChar(number[1]);
            arow = new string(a_array);
            actionmaparray[y] = "    " + arow;

            //tile map operations
            string trow = tilemaparray[y].Remove(0, 4);
            char[] t_array = trow.ToArray();
            string tile = info[3];
            t_array[x1] = Convert.ToChar(tile[0]);
            t_array[x2] = Convert.ToChar(tile[1]);

            trow = new string(t_array);



            tilemaparray[y] = "    " + trow;
        }




        //save to file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //adds all map data arrays into reformatted strings
            actionclassmap = buildmaps(actionclassmaparray);
            actionmap = buildmaps(actionmaparray);
            tilemap = buildmaps(tilemaparray);


            //saves to mapfile
            XmlNodeList actionclassmaps = mapfile.GetElementsByTagName("actionClassMap");
            actionclassmaps[0].InnerText = actionclassmap;
            XmlNodeList actionmaps = mapfile.GetElementsByTagName("actionMap");
            actionmaps[0].InnerText = actionmap;
            XmlNodeList tilemaps = mapfile.GetElementsByTagName("tileMap");
            tilemaps[0].InnerText = tilemap;
            XmlNodeList strings = mapfile.GetElementsByTagName("string");


            mapfile.Save(filename);
        }

        public string buildmaps (string[] mapribbons)
        {
            string map = "";
            for(int i = 0; i<mapsize; i++)
            {
                map += mapribbons[i] + "\n";
            }
            map += mapribbons[mapsize - 1];
            return map;
        }



        //qwik edit junk

        private void qwikEditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void actionClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(Form3 window = new Form3())
            {
                if (window.ShowDialog() == DialogResult.OK)
                {
                    if (window.output.Length == 1)
                    { 
                    defaultvalue = window.output;
                    qwikedit = "ac";
                    window.Close();
                    }
                }
            }
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form3 window = new Form3())
            {
                if (window.ShowDialog() == DialogResult.OK)
                {
                    if(window.output.Length == 2)
                    { 
                    defaultvalue = window.output;
                    qwikedit = "t";
                    window.Close();
                    }
                }
            }
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defaultvalue = "..";
            qwikedit = "off";
        }


        //debug functions!
        public void tilepeek(string coords)
        {
            string[] list = new string[2];
            int x;
            int y;

            list = coords.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);


            x = Convert.ToInt32(list[0]);
            y = Convert.ToInt32(list[1]) + 1;

            //dual character operations
            int[] dualcharcoords = dualchar(x);
            int x1 = dualcharcoords[0] - 1;
            int x2 = dualcharcoords[1] - 1;




            //acmap operations
            string acrow = actionclassmaparray[y].Remove(0, 4);
            string acchar = acrow[x].ToString();

            //amap operations
            string arow = actionmaparray[y].Remove(0, 4);
            string action = Convert.ToString(arow[x1]) + Convert.ToString(arow[x2]);

            //tile map operations
            string trow = tilemaparray[y].Remove(0, 4);
            string tchar = Convert.ToString(trow[x1]) + Convert.ToString(trow[x2]);


            edittile(coords);



        }
        public string[] tiledata(string coords)
        {
            string[] list = new string[2];
            int x;
            int y;
            string[] data = new string[4];

            list = coords.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);


            x = Convert.ToInt32(list[0]);
            y = Convert.ToInt32(list[1]) + 1;

            //dual character operations
            int[] dualcharcoords = dualchar(x);
            int x1 = dualcharcoords[0] - 1;
            int x2 = dualcharcoords[1] - 1;




            //acmap operations
            string acrow = actionclassmaparray[y].Remove(0, 4);
            string acchar = acrow[x].ToString();

            //amap operations
            string arow = actionmaparray[y].Remove(0, 4);
            string action = Convert.ToString(arow[x1]) + Convert.ToString(arow[x2]);

            //tile map operations
            string trow = tilemaparray[y].Remove(0, 4);
            string tchar = Convert.ToString(trow[x1]) + Convert.ToString(trow[x2]);

            data[0] = coords;
            data[1] = acchar;
            data[2] = action;
            data[3] = tchar;

            return data;



        }

    }
}