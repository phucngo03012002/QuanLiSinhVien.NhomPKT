using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.DataLayer
{
    public class Database
    {
        private string path = string.Empty;

        public Database(string path)
        {
            this.path = path;
        }
        //phuong thuc doc file
        public List<User> ReadUserFromFileINI()
        {
            List<User> Users = null;
            //cau truc doc file
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string line = string.Empty;
                    User user;
                    Users = new List<User>();
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] vs = line.Split(',');
                            user = new User()
                            {
                                ID = Convert.ToInt32(vs[0]),
                                TaiKhoan = vs[1],
                                MatKhau = vs[2],
                                HoVaTen = vs[3],
                            };
                            Users.Add(user);
                        }
                    }
                }
            }
            return Users;
        }
        //public bool WriterUserToFileINI()
        //{
        //    bool result = false;
        //    if (File.Exists(path))
        //    {
        //        File.Delete(path);
        //    }
        //    using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
        //    {
        //        using (StreamWriter streamWriter = new StreamWriter(fileStream))
        //        {
        //            foreach (User item in users)
        //            {
        //                streamWriter.WriteLine(item.ToString());
        //            }
        //        }
        //    }
        //    return result;
        //}
    }
}
