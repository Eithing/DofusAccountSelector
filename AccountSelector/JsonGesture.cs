using AccountSelector.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace AccountSelector
{
    public class JsonGesture
    {
        public List<Account> DeserializeJsonObject()
        {
            try
            {
                var fileReaded = File.ReadAllText("Preferences.json");
                return JsonConvert.DeserializeObject<List<Account>>(fileReaded);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SerializeJsonObject(ListView LV)
        {
            List<Account> accounts = new List<Account>();
            foreach(ListViewItem item in LV.Items)
            {
                accounts.Add(new Account { Image = item.ImageKey, IsActive = item.Checked, Name = item.Text });
            }

            string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);

            using (StreamWriter sw = File.CreateText("Preferences.json"))
            {
                sw.WriteLine(json);
            }
        }


        public List<Params> DeserializeParams()
        {
            try
            {
                var fileReaded = File.ReadAllText("Params.json");
                return JsonConvert.DeserializeObject<List<Params>>(fileReaded);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public void SerializeParams(List<Params> paramsList)
        {
            string json = JsonConvert.SerializeObject(paramsList, Formatting.Indented);

            using (StreamWriter sw = File.CreateText("Params.json"))
            {
                sw.WriteLine(json);
            }
        }
    }
}
