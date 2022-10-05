using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.DataLayer
{
    internal class Database
    {
            private string path = string.Empty;
            public Database(string path)
            {
                this.path = path;
            }
            public List<User> ReadUserFromFileINI()
            {
                List<User> users = null;
                //cau truc doc file
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        string line = string.Empty;
                        User user;
                        users = new List<User>();
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
                                    NhoMatKhau = Convert.ToBoolean(vs[4])
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
                return users;
            }

            //Ghi file
            public bool GhiFile(string path, List<User> users)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                {
                    using (StreamWriter streamWrite = new StreamWriter(fileStream))
                    {
                        foreach (User item in users)
                        {
                            streamWrite.WriteLine(string.Format("{0},{1},{2},{3},{4}", item.ID, item.TaiKhoan, item.MatKhau, item.HoVaTen, item.NhoMatKhau));
                        }
                    }
                }
                return true;
            }
    }
}
