using Demo.Models;
using Demo.Models.Data;
using Demo.Services;
using Demo.Views;
using DevExpress.Mvvm;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace Demo.ViewModels
{
    public class BrowseApplications : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Demo.Models.Application> applications = ApplicationService.GetApplications();
        public List<Demo.Models.Application> Applications
        {
            get { return applications; }
            set
            {
                applications = value;
                NotifyPropertyChanged(nameof(Applications));
            }
        }

        //Статистика

        public static Demo.Models.Application? SelectedApplication { get; set; }
        //Авторизация
        public static string fioUser;
        public static string idUser;
        private RelayCommand _authorizationWnd;
        public RelayCommand AuthorizationWnd
        {
            get
            {
                return _authorizationWnd ?? new RelayCommand(obj =>
                {
                    AuthorizationWndMethod();
                });
            }
        }
        public void AuthorizationWndMethod()
        {
            Window currentWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            string login = MainWindow.mainWindow.tbLogin.Text;
            string password = MainWindow.mainWindow.tbPassword.Text;
            var user = UserServices.GetUserByLoginAndPassword(login, password);
            if (user != null)
            {
                var roleUser = UserServices.GetRoleNameByUserId(user.IdRole);
                fioUser = UserServices.GetFIOUser(user.IdUser);
                idUser = UserServices.GetIDPerformer(user.IdUser);
                switch (roleUser)
                {
                    case "Диспетчер":
                        OpenAdminWndMethod();
                        break;
                    case "Исполнитель":
                        applicationsPerformer = ApplicationService.GetApplicationsByIDPerformer(int.Parse(idUser));
                        OpenPerformerWndMethod();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неверно введены данные.");
            }
        }
        //Возврат на авторизацию
        private RelayCommand openMainWindowWnd;
        public RelayCommand OpenMainWindowWnd
        {
            get
            {
                return openMainWindowWnd ?? new RelayCommand(obj =>
                {
                    OpenMainWindowWndMethod();
                });
            }
        }
        public static void OpenMainWindowWndMethod()
        {
            Window currentWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                MainWindow mainWindow = new()
                {
                    Owner = System.Windows.Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                mainWindow.ShowDialog();
                currentWindow.Close();
            }
        }
        //Открытие окна с добавлением заявки
        private RelayCommand openAddApplicationWnd;
        public RelayCommand OpenAddApplicationtWnd
        {
            get
            {
                return openAddApplicationWnd ?? new RelayCommand(obj =>
                {
                    OpenAddApplicationWndMethod();
                });
            }
        }
        public static void OpenAddApplicationWndMethod()
        {
            Window currentWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                AddApplication addApplication = new()
                {
                    Owner = System.Windows.Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                addApplication.ShowDialog();
                currentWindow.Close();
            }
        }
        //Поиск, сортировка и фильтр
        public string Search
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: UpdateApplication); }
        }
        public List<string> Filters { get; set; } = ["Не выполнено", "В работе", "Выполнено"];
        public string SelectedFilter
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: UpdateApplication); }
        }
        private void UpdateApplication()
        {
            var currentApplication = ApplicationService.GetApplications();

            if (!string.IsNullOrEmpty(SelectedFilter))
            {
                switch (SelectedFilter)
                {
                    case "Не выполнено":
                        currentApplication = currentApplication.Where(a => a.StatusApplication == "Не выполнено").ToList();
                        break;
                    case "В работе":
                        currentApplication = currentApplication.Where(a => a.StatusApplication == "В работе").ToList();
                        break;
                    case "Выполнено":
                        currentApplication = currentApplication.Where(a => a.StatusApplication == "Выполнено").ToList();
                        break;
                }
            }

            if (!string.IsNullOrEmpty(Search))
            {
                currentApplication = currentApplication.Where(a => a.DescriptionProblem.ToLower().Contains(Search.ToLower()) || a.IdApplication.ToString().Contains(Search)).ToList();
            }

            Applications = currentApplication;
        }

        //Добавление заявки
        public static List<string> PerformersList { get; set; } = UserServices.GetPerformersList();
        public static List<string> EquipmentsList { get; set; } = ApplicationService.GetEquipmentsList();
        public static List<string> MalfunctionList { get; set; } = ApplicationService.GetMalfunctionList();
        public List<string> PriorityList { get; set; } = ["Низкий", "Средний", "Высокий"];
        private RelayCommand addApplicationWnd;
        public RelayCommand AddApplicationWnd
        {
            get
            {
                return addApplicationWnd ?? new RelayCommand(obj =>
                {
                    AddApplicationWndMethod();
                });
            }
        }
        public static bool CheckPhoneNumberFormat(string phoneNumber)
        {
            string pattern = @"^8\d{10}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
        public static bool CheckDateFormat(string date)
        {
            string pattern = @"^\d{4}-\d{2}-\d{2}$";
            return Regex.IsMatch(date, pattern);
        }
        public static void AddApplicationWndMethod()
        {
            string applicationPerformerSelect = AddApplication.addApplication.cbPerformer.SelectedItem.ToString();
            string phoneCustomer = AddApplication.addApplication.tbPhoneCustomer.Text;
            string applicationDate = AddApplication.addApplication.tbDate.Text;
            string applicationEquipmentCB = AddApplication.addApplication.cbEquipment.SelectedItem.ToString();
            string applicationEquipmentTB = AddApplication.addApplication.tbEquipment.Text;
            string applicationEquipmentEnabled = AddApplication.addApplication.isInputEnabled.ToString();
            string applicationMalfuctionCB = AddApplication.addApplication.cbMalfunction.SelectedItem.ToString();
            string applicationMalfuctionTB = AddApplication.addApplication.tbMalfunction.Text;
            string applicationMalfuctionEnabled = AddApplication.addApplication.isInputEnabled1.ToString();
            string applicationDescription = AddApplication.addApplication.tbDescription.Text;
            string applicationPriority = AddApplication.addApplication.cbPriority.SelectedItem.ToString();

            string applicationEquipmentSelect = "";
            if (applicationEquipmentCB == "-1" && applicationEquipmentEnabled == "True")
            {
                if (!string.IsNullOrEmpty(applicationEquipmentTB))
                {
                    applicationEquipmentSelect = applicationEquipmentTB;
                }
                else
                {
                    MessageBox.Show("Оборудование не выбрано.");
                }
            }
            else if (string.IsNullOrEmpty(applicationEquipmentTB) && applicationEquipmentEnabled == "False")
            {
                if (applicationEquipmentCB != "-1")
                {
                    applicationEquipmentSelect = applicationEquipmentCB;
                }
                else
                {
                    MessageBox.Show("Оборудование не выбрано.");
                }
            }
            string applicationMalfuctionSelect = "";
            if (applicationMalfuctionCB == "-1" && applicationMalfuctionEnabled == "True")
            {
                if (!string.IsNullOrEmpty(applicationMalfuctionTB))
                {
                    applicationMalfuctionSelect = applicationMalfuctionTB;
                }
                else
                {
                    MessageBox.Show("Оборудование не выбрано.");
                }
            }
            else if (string.IsNullOrEmpty(applicationMalfuctionTB) && applicationMalfuctionEnabled == "False")
            {
                if (applicationMalfuctionCB != "-1")
                {
                    applicationMalfuctionSelect = applicationMalfuctionCB;
                }
                else
                {
                    MessageBox.Show("Оборудование не выбрано.");
                }
            }
            if (applicationPriority != "-1")
            {
                List<string> strings = [applicationPerformerSelect, phoneCustomer, applicationDate, applicationEquipmentSelect, applicationMalfuctionSelect, applicationDescription];
                if (strings.All(s => !string.IsNullOrEmpty(s)))
                {
                    int applicationEquipment = -1;
                    int applicationMalfuction = -1;

                    using (ApplicationsContext context = new ApplicationsContext())
                    {
                        applicationEquipment = ApplicationService.GetOrCreateEquipmentID(applicationEquipmentSelect, context);
                        applicationMalfuction = ApplicationService.GetOrCreateMalfuctionID(applicationMalfuctionSelect, context);
                    }
                    if (CheckPhoneNumberFormat(phoneCustomer) == true)
                    {
                        if (CheckDateFormat(applicationDate) == true)
                        {
                            int applicationPerformer = UserServices.GetPerformerIDByName(applicationPerformerSelect);

                            using (ApplicationsContext context = new ApplicationsContext())
                            {
                                var newApplication = new Demo.Models.Application
                                {
                                    IdUser = applicationPerformer,
                                    CustomersNumber = phoneCustomer,
                                    DateAddition = DateOnly.Parse(applicationDate),
                                    IdEquipment = applicationEquipment,
                                    IdMalfunction = applicationMalfuction,
                                    DescriptionProblem = applicationDescription,
                                    StatusApplication = "Не выполнено",
                                    Priority = applicationPriority
                                };
                                context.Applications.Add(newApplication);
                                context.SaveChanges();
                                MessageBox.Show("Заявка принята.");
                                OpenAdminWndMethod();
                            }
                        }
                        else { MessageBox.Show("Неверный формат даты"); }
                    }
                    else { MessageBox.Show("Неверный формат номера телефона."); }
                }
                else { MessageBox.Show("Не все строки заполнены."); }
            }
            else { MessageBox.Show("Не выбран приоритет заявки."); }
        }
        //Открытие окна с редактированием статуса
        private RelayCommand openEditApplicationWnd;
        public RelayCommand OpenEditApplicationWnd
        {
            get
            {
                return openEditApplicationWnd ?? new RelayCommand(obj =>
                {
                    OpenEditApplicationWndMethod();
                });
            }
        }
        public static void OpenEditApplicationWndMethod()
        {
            Window currentWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                EditApplication editApplication = new(SelectedApplication)
                {
                    Owner = System.Windows.Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                string selectPerformer = UserServices.GetPerformerFIOByID(SelectedApplication.IdUser);
                editApplication.cbPermormer.SelectedItem = PerformersList.FirstOrDefault(p => p == selectPerformer);
                editApplication.ShowDialog();
                currentWindow.Close();
            }
        }
        //Редактирование статуса
        private RelayCommand editApplicationWnd;
        public RelayCommand EditApplicationWnd
        {
            get
            {
                return editApplicationWnd ?? new RelayCommand(obj =>
                {
                    EditApplicationWndMethod();
                });
            }
        }
        public static void EditApplicationWndMethod()
        {
            string applicationStatus = EditApplication.editApplication.cbStatus.SelectedItem.ToString();
            string appplicationPerformerSelect = EditApplication.editApplication.cbPermormer.SelectedItem.ToString();
            using (ApplicationsContext context = new ApplicationsContext())
            {
                int applicationPerformer = UserServices.GetPerformerIDByName(appplicationPerformerSelect);
                var applicationToUpdate = context.Applications.Find(SelectedApplication.IdApplication);
                if (applicationToUpdate != null)
                {
                    applicationToUpdate.StatusApplication = applicationStatus;
                    applicationToUpdate.IdUser = applicationPerformer;
                    context.SaveChanges();
                    MessageBox.Show("Статус успешно обновлен.");
                    OpenAdminWndMethod();
                }
            }
        }
        public List<string> StatusList { get; set; } = ["Не выполнено", "В работе", "Выполнено"];
        //Возврат на окно диспетчера
        private RelayCommand openAdminWnd;
        public RelayCommand OpenAdminWnd
        {
            get
            {
                return openAdminWnd ?? new RelayCommand(obj =>
                {
                    OpenAdminWndMethod();
                });
            }
        }
        public static void OpenAdminWndMethod()
        {
            Window currentWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                DispatcherWindow dispatcherWindow = new()
                {
                    Owner = System.Windows.Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                dispatcherWindow.tUser.Text = fioUser;
                dispatcherWindow.ShowDialog();
                currentWindow.Close();
            }
        }
        public static List<Demo.Models.Application> applicationsPerformer;
        public static List<Demo.Models.Application> ApplicationsByIDPerformer { get; set; }
        //Возврат на окно исполнителя
        private RelayCommand openPerformerWnd;
        public RelayCommand OpenPerformerWnd
        {
            get
            {
                return openPerformerWnd ?? new RelayCommand(obj =>
                {
                    OpenPerformerWndMethod();
                });
            }
        }
        public static void OpenPerformerWndMethod()
        {
            Window currentWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                PerformerView performerView = new()
                {
                    Owner = System.Windows.Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                performerView.tUser.Text = fioUser;
                performerView.tID.Text = idUser;
                performerView.dgApplication.ItemsSource = applicationsPerformer;
                performerView.ShowDialog();
                currentWindow.Close();
            }
        }
        // Переход на исполнение заявки
        private RelayCommand openExecuteApplicationWnd;
        public RelayCommand OpenExecuteApplicationWnd
        {
            get
            {
                return openExecuteApplicationWnd ?? new RelayCommand(obj =>
                {
                    OpenExecuteApplicationWndMethod();
                });
            }
        }
        public static void OpenExecuteApplicationWndMethod()
        {
            Window currentWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                ExecuteApplication executeApplication = new(SelectedApplication)
                {
                    Owner = System.Windows.Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                executeApplication.ShowDialog();
                currentWindow.Close();
            }
        }
        public List<string> SparePartsList { get; set; } = SparePartsService.GetSparepartsList();
        //Исполнение заявки
        private RelayCommand executeApplicationWnd;
        public RelayCommand ExecuteApplicationWnd
        {
            get
            {
                return executeApplicationWnd ?? new RelayCommand(obj =>
                {
                    ExecuteApplicationWndMethod();
                });
            }
        }
        public static void ExecuteApplicationWndMethod()
        {
            string applicationSparePartsCB = "";
            if (ExecuteApplication.executeApplication.cbSpareParts.SelectedItem != null)
            {
                applicationSparePartsCB = ExecuteApplication.executeApplication.cbSpareParts.SelectedItem.ToString();
            }
            else { MessageBox.Show("Запчасть не выбрана не выбранa."); }
            string applicationSparePartsTB = ExecuteApplication.executeApplication.tbSpapePartsName.Text;
            string applicationSparePartsEnabled = ExecuteApplication.executeApplication.isInputEnabled.ToString();
            string applacationSparePartsCost = ExecuteApplication.executeApplication.tbSpapePartsCost.Text;
            string applacationSparePartsCount = ExecuteApplication.executeApplication.tbSpapePartsCount.Text;

            string applicationSparePartsSelect = "";
            if (applicationSparePartsCB == "-1" && applicationSparePartsEnabled == "True")
            {
                if (!string.IsNullOrEmpty(applicationSparePartsTB))
                {
                    applicationSparePartsSelect = applicationSparePartsTB;
                    int applicationSpareParts;
                    if (int.TryParse(applacationSparePartsCost, out int result) && int.TryParse(applacationSparePartsCount, out int result2))
                    {
                        applicationSpareParts = SparePartsService.GetOrCreateSparepartID(applicationSparePartsSelect, SelectedApplication.IdApplication.ToString(), applacationSparePartsCost, applacationSparePartsCount);
                        MessageBox.Show("Запчасть заказана.");
                        OpenPerformerWndMethod();
                    }
                    else { MessageBox.Show("Неверный формат количества/стоимости запчасти."); }
                }
                else
                {
                    MessageBox.Show("Запчасть не выбрана.");
                }
            }
            else if (string.IsNullOrEmpty(applicationSparePartsTB) && applicationSparePartsEnabled == "False")
            {
                if (applicationSparePartsCB != "-1")
                {
                    applicationSparePartsSelect = applicationSparePartsCB;
                    int applicationSpareParts;
                    if (int.TryParse(applacationSparePartsCost, out int result) && int.TryParse(applacationSparePartsCount, out int result2))
                    {
                        applicationSpareParts = SparePartsService.GetOrCreateSparepartID(applicationSparePartsSelect, SelectedApplication.IdApplication.ToString(), applacationSparePartsCost, applacationSparePartsCount);
                        MessageBox.Show("Запчасть заказана.");
                        OpenPerformerWndMethod();
                    }
                    else { MessageBox.Show("Неверный формат количества/стоимости запчасти."); }
                }
                else
                {
                    MessageBox.Show("Запчасть не выбранa.");
                }
            }
        }
        //Переход на создание отчета
        private RelayCommand createReportWnd;
        public RelayCommand CreateReportWnd
        {
            get
            {
                return createReportWnd ?? new RelayCommand(obj =>
                {
                    CreateReportWndMethod();
                });
            }
        }
        public static void CreateReportWndMethod()
        {
            Window currentWindow = System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                CreateReport createReport = new()
                {
                    Owner = System.Windows.Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                createReport.ShowDialog();
                currentWindow.Close();
            }
        }
    }
}
