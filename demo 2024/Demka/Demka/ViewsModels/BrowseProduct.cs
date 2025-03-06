using Demka.Models;
using Demka.Models.Data;
using Demka.Services;
using Demka.Views;
using DevExpress.Mvvm;
using System.ComponentModel;
using System.IO;
using System.Windows;


namespace Demka.ViewsModels
{
    public class BrowseProduct : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Product> products = ProductServices.GetProducts();
        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                NotifyPropertyChanged(nameof(Products));
            }
        }

        public static Product? SelectedProduct { get; set; }
        // Вывод статуса заказа
        public List<string> OrderStatuses { get; set; } = ["Новый", "В процессе", "Завершен"];
        // Вывод пунктов выдачи
        public List<string> PickupPointList { get; set; } = PickuppointServices.GetAddresses();
        //Сортировка, фильтрация, поиск в ViewProducts
        public List<string> Sorts { get; set; } = ["По умолчанию", "По возрастанию", "По убыванию"];
        public List<string> Filters { get; set; } = ["Все диапазоны", "0-5%", "5-9%", "9% и более"];
        public string SelectedSort
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: UpdateProduct); }
        }
        public string SelectedFilter
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: UpdateProduct); }
        }
        public string Search
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: UpdateProduct); }
        }

        private void UpdateProduct()
        {
            var currentProduct = ProductServices.GetProducts();

            if (!string.IsNullOrEmpty(SelectedFilter))
            {
                switch (SelectedFilter)
                {
                    case "0-5%":
                        currentProduct = currentProduct.Where(p => (float)p.ProductDiscountAmount >= 0 && (float)p.ProductDiscountAmount < 5).ToList();
                        break;
                    case "5-9%":
                        currentProduct = currentProduct.Where(p => (float)p.ProductDiscountAmount >= 5 && (float)p.ProductDiscountAmount < 9).ToList();
                        break;
                    case "9% и более":
                        currentProduct = currentProduct.Where(p => (float)p.ProductDiscountAmount >= 9).ToList();
                        break;
                }
            }

            if (!string.IsNullOrEmpty(Search))
            {
                currentProduct = currentProduct.Where(p => p.ProductName.ToLower().Contains(Search.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(SelectedSort))
            {
                switch (SelectedSort)
                {
                    case "По возрастанию":
                        currentProduct = currentProduct.OrderBy(p => p.ProductCost).ToList();
                        break;
                    case "По убыванию":
                        currentProduct = currentProduct.OrderByDescending(p => p.ProductCost).ToList();
                        break;
                }
            }

            Products = currentProduct;
        }

        //Вход в качестве гостя
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
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                MainWindow mainWindow = new()
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                mainWindow.ShowDialog();
                currentWindow.Close();
            }
        }
        private RelayCommand openViewGuestWnd;
        public RelayCommand OpenViewGuestWnd
        {
            get
            {
                return openViewGuestWnd ?? new RelayCommand(obj =>
                {
                    OpenViewGuestWndMethod();
                });
            }
        }
        public static void OpenViewGuestWndMethod()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                ViewProducts viewProducts = new()
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                viewProducts.ShowDialog();
                currentWindow.Close();
            }
        }

        //Авторизация
        public static string fioUser;
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
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            string login = MainWindow.mainWindow.tbLogin.Text;
            string password = MainWindow.mainWindow.tbPassword.Text;
            var user = UserServices.GetUserByLoginAndPassword(login, password);
            if (user != null)
            {
                var roleUser = UserServices.GetRoleNameByUserId(user.UserRole);
                fioUser = UserServices.GetFIOUser(user.UserId);
                switch (roleUser)
                {
                    case "Администратор":
                        OpenAdminWndMethod();
                        break;
                    case "Клиент":
                        OpenViewProductWndMethod();
                        break;
                    case "Менеджер":
                        OpenManagerWndMethod();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неверно введены данные.");
                Captcha captcha = new Captcha();
                MainWindow.mainWindow.frameToCaptcha.NavigationService.Navigate(captcha, Visibility.Visible);
            }
        }
        private RelayCommand openViewProductWnd;
        public RelayCommand OpenViewProductWnd
        {
            get
            {
                return openViewProductWnd ?? new RelayCommand(obj =>
                {
                    OpenViewProductWndMethod();
                });
            }
        }
        public static void OpenViewProductWndMethod()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                ViewProducts viewProducts = new()
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                viewProducts.tUser.Text = fioUser;
                viewProducts.ShowDialog();
                currentWindow.Close();
            }
        }

        //Заказ
        private RelayCommand openCartWnd;
        public RelayCommand OpenCartWnd
        {
            get
            {
                return openCartWnd ?? new RelayCommand(obj =>
                {
                    OpenCartWndMethod();
                });
            }
        }
        public static void OpenCartWndMethod()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                Cart cart = new()
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                cart.ShowDialog();
                currentWindow.Close();
            }
        }
        private RelayCommand openTicketWnd;
        public RelayCommand OpenTicketWnd
        {
            get
            {
                return openTicketWnd ?? new RelayCommand(obj =>
                {
                    OpenTicketWndMethod();
                });
            }
        }
        public static void OpenTicketWndMethod()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                Ticket ticket = new()
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                ticket.ShowDialog();
                currentWindow.Close();
            }
        }

        //Все, что связано с администратором
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
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                Admin admin = new()
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                admin.tUser.Text = fioUser;
                admin.ShowDialog();
                currentWindow.Close();
            }
        }
        ////Добавление товара
        public List<string> CategoriesList { get; set; } = ProductServices.GetCategoryList();
        public List<string> ManufacturerLis { get; set; } = ProductServices.GetManufacturerList();
        public List<string> DeliverersList { get; set; } = ProductServices.GetDeliverersList();

        private RelayCommand openAddProductWnd;
        public RelayCommand OpenAddProductWnd
        {
            get
            {
                return openAddProductWnd ?? new RelayCommand(obj =>
                {
                    OpenAddProductWndMethod();
                });
            }
        }
        public static void OpenAddProductWndMethod()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                AddProduct addProduct = new()
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                addProduct.ShowDialog();
                currentWindow.Close();
            }
        }
        private RelayCommand addProductWnd;
        public RelayCommand AddProductWnd
        {
            get
            {
                return addProductWnd ?? new RelayCommand(obj =>
                {
                    AddProductWndMethod();
                });
            }
        }
        public static void AddProductWndMethod()
        {
            string productArticle = AddProduct.addProduct.tbProductArticleNumber.Text;
            string productCategorySelect = AddProduct.addProduct.cbCategory.SelectedItem.ToString();
            string productName = AddProduct.addProduct.tbProductName.Text;
            string productManufacturerSelect = AddProduct.addProduct.cbManufacturer.SelectedItem.ToString();
            string productDeliverySelect = AddProduct.addProduct.cbDelivery.SelectedItem.ToString();
            string productDescription = AddProduct.addProduct.tbProductDescription.Text;
            string productImageSelect = AddProduct.addProduct.tbImage.Text;
            string productCost = AddProduct.addProduct.tbProductCost.Text;
            string productQuantity = AddProduct.addProduct.tbQuantity.Text;
            string productDiscountAmount = AddProduct.addProduct.tbProductDiscountAmount.Text;
            string productDiscount = AddProduct.addProduct.tbCurrentDiscount.Text;

            string productUnit = "";
            if (AddProduct.addProduct.rbPacking.IsChecked == true)
            {
                productUnit = AddProduct.addProduct.rbPacking.Content.ToString();
            }
            else if (AddProduct.addProduct.rbPiece.IsChecked == true)
            {
                productUnit = AddProduct.addProduct.rbPiece.Content.ToString();
            }

            List<string> strings = new List<string> { productArticle, productCategorySelect, productName, productManufacturerSelect, productDeliverySelect,
            productDescription, productCost, productQuantity, productDiscountAmount, productDiscount, productUnit};
            if (strings.All(s => !string.IsNullOrEmpty(s)))
            {
                if (ProductServices.ProductArticleOccupancy(productArticle) == true)
                {
                    int productCategory = ProductServices.GetCategoryIDByName(productCategorySelect);
                    int productManufacturer = ProductServices.GetManufacturerIDByName(productManufacturerSelect);
                    int productDelivery = ProductServices.GetDeliveryIDByName(productDeliverySelect);
                    if (productCategory != -1 || productManufacturer != -1 || productDelivery != -1)
                    {
                        if (decimal.TryParse(productCost, out decimal result))
                        {
                            if (sbyte.TryParse(productDiscountAmount, out sbyte result1) && sbyte.TryParse(productDiscount, out sbyte result2))
                            {
                                if (int.TryParse(productQuantity, out int result3))
                                {
                                    if (productImageSelect != string.Empty)
                                    {
                                        string productPhoto = System.IO.Path.GetFileName(productImageSelect);
                                        string pathTo = @"C:\Users\Я\source\repos\Demka\Demka\Resources\ProductImage\" + productPhoto;
                                        File.Copy(productImageSelect, pathTo, true);


                                        using (var db = new TradeContext())
                                        {
                                            var newProduct = new Product
                                            {
                                                ProductArticleNumber = productArticle,
                                                ProductName = productName,
                                                ProductDescription = productDescription,
                                                ProductUnit = productUnit,
                                                ProductCost = Convert.ToDecimal(productCost),
                                                ProductMaxDiscountAmount = Convert.ToSByte(productDiscountAmount),
                                                ManufacturerId = productManufacturer,
                                                DeliveryId = productDelivery,
                                                CategoryId = productCategory,
                                                ProductDiscountAmount = Convert.ToSByte(productDiscount),
                                                ProductQuantityInStock = Convert.ToInt32(productQuantity),
                                                ProductPhoto = productPhoto
                                            };
                                            db.Products.Add(newProduct);
                                            db.SaveChanges();
                                            MessageBox.Show("Товар успешно добавлен.");
                                            OpenAdminWndMethod();
                                        }
                                    }
                                    else
                                    {
                                        using (var db = new TradeContext())
                                        {
                                            var newProduct = new Product
                                            {
                                                ProductArticleNumber = productArticle,
                                                ProductName = productName,
                                                ProductDescription = productDescription,
                                                ProductUnit = productUnit,
                                                ProductCost = Convert.ToDecimal(productCost),
                                                ProductMaxDiscountAmount = Convert.ToSByte(productDiscountAmount),
                                                ManufacturerId = productManufacturer,
                                                DeliveryId = productDelivery,
                                                CategoryId = productCategory,
                                                ProductDiscountAmount = Convert.ToSByte(productDiscount),
                                                ProductQuantityInStock = Convert.ToInt32(productQuantity),
                                                ProductPhoto = null
                                            };
                                            db.Products.Add(newProduct);
                                            db.SaveChanges();
                                            MessageBox.Show("Товар успешно добавлен.");
                                            OpenAdminWndMethod();
                                        }
                                    }
                                }
                                else { MessageBox.Show("Неверный формат количества товара."); }
                            }
                            else { MessageBox.Show("Неверный формат скидки."); }
                        }
                        else { MessageBox.Show("Неверный формат цены."); }
                    }
                    else { MessageBox.Show("Некорректно выбранные данные."); }
                }
                else { MessageBox.Show("Добавление товара с данным артикулом невозможно."); }
            }
            else { MessageBox.Show("Не все строки заполнены."); }
        }
        ////Редактирование товара
        private RelayCommand openEditProductWnd;
        public RelayCommand OpenEditProductWnd
        {
            get
            {
                return openEditProductWnd ?? new RelayCommand(obj =>
                {
                    OpenEditProductWndMethod();
                });
            }
        }
        public static void OpenEditProductWndMethod()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                EditProduct editProduct = new(SelectedProduct)
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                editProduct.ShowDialog();
                currentWindow.Close();
            }
        }
        private RelayCommand editProductWnd;
        public RelayCommand EditProductWnd
        {
            get
            {
                return editProductWnd ?? new RelayCommand(obj =>
                {
                    EditProductWndMethod();
                });
            }
        }
        public static void EditProductWndMethod()
        {
            string newDeliverySelect = EditProduct.editProduct.cbDelivery.SelectedItem.ToString();
            string newDescription = EditProduct.editProduct.tbProductDescription.Text;
            string newImageSelect = EditProduct.editProduct.tbImage.Text;
            string newCost = EditProduct.editProduct.tbProductCost.Text;
            string newQuantity = EditProduct.editProduct.tbQuantity.Text;
            string newMaxDiscountAmount = EditProduct.editProduct.tbProductDiscountAmount.Text;
            string newDiscountAmount = EditProduct.editProduct.tbCurrentDiscount.Text;

            List<string> strings = new List<string> { newDeliverySelect, newDescription, newCost, newQuantity, newMaxDiscountAmount, newDiscountAmount };
            if (strings.All(s => !string.IsNullOrEmpty(s)))
            {
                int productDelivery = ProductServices.GetDeliveryIDByName(newDeliverySelect);
                if (productDelivery != -1)
                {
                    if (decimal.TryParse(newCost, out decimal result))
                    {
                        if (sbyte.TryParse(newMaxDiscountAmount, out sbyte result1) && sbyte.TryParse(newDiscountAmount, out sbyte result2))
                        {
                            if (int.TryParse(newQuantity, out int result3))
                            {
                                if (newImageSelect != string.Empty)
                                {
                                    string newPhoto = System.IO.Path.GetFileName(newImageSelect);
                                    string pathTo = @"C:\Users\Я\source\repos\Demka\Demka\Resources\ProductImage\" + newPhoto;
                                    if (File.Exists(pathTo))
                                    {
                                        using (var db = new TradeContext())
                                        {
                                            var productToUpdate = db.Products.Find(SelectedProduct.ProductArticleNumber);
                                            if (productToUpdate != null)
                                            {
                                                productToUpdate.DeliveryId = productDelivery;
                                                productToUpdate.ProductDescription = newDescription;
                                                productToUpdate.ProductCost = Convert.ToDecimal(newCost);
                                                productToUpdate.ProductQuantityInStock = Convert.ToInt32(newQuantity);
                                                productToUpdate.ProductMaxDiscountAmount = Convert.ToSByte(newMaxDiscountAmount);
                                                productToUpdate.ProductDiscountAmount = Convert.ToSByte(newDiscountAmount);

                                                db.SaveChanges();
                                                MessageBox.Show("Информация о товаре обновлена.");
                                                OpenAdminWndMethod();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        File.Copy(newImageSelect, pathTo, true);

                                        using (var db = new TradeContext())
                                        {
                                            var productToUpdate = db.Products.Find(SelectedProduct.ProductArticleNumber);
                                            if (productToUpdate != null)
                                            {
                                                productToUpdate.DeliveryId = productDelivery;
                                                productToUpdate.ProductDescription = newDescription;
                                                productToUpdate.ProductPhoto = newPhoto;
                                                productToUpdate.ProductCost = Convert.ToDecimal(newCost);
                                                productToUpdate.ProductQuantityInStock = Convert.ToInt32(newQuantity);
                                                productToUpdate.ProductMaxDiscountAmount = Convert.ToSByte(newMaxDiscountAmount);
                                                productToUpdate.ProductDiscountAmount = Convert.ToSByte(newDiscountAmount);

                                                db.SaveChanges();
                                                MessageBox.Show("Информация о товаре обновлена.");
                                                OpenAdminWndMethod();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    using (var db = new TradeContext())
                                    {
                                        var productToUpdate = db.Products.Find(SelectedProduct.ProductArticleNumber);
                                        if (productToUpdate != null)
                                        {
                                            productToUpdate.DeliveryId = productDelivery;
                                            productToUpdate.ProductDescription = newDescription;
                                            productToUpdate.ProductPhoto = null;
                                            productToUpdate.ProductCost = Convert.ToDecimal(newCost);
                                            productToUpdate.ProductQuantityInStock = Convert.ToInt32(newQuantity);
                                            productToUpdate.ProductMaxDiscountAmount = Convert.ToSByte(newMaxDiscountAmount);
                                            productToUpdate.ProductDiscountAmount = Convert.ToSByte(newDiscountAmount);

                                            db.SaveChanges();
                                            MessageBox.Show("Информация о товаре обновлена.");
                                            OpenAdminWndMethod();
                                        }
                                    }
                                }
                            }
                            else { MessageBox.Show("Неверный формат количества товара."); }
                        }
                        else { MessageBox.Show("Неверный формат скидки."); }
                    }
                    else { MessageBox.Show("Неверный формат цены."); }
                }
                else { MessageBox.Show("Некорректно выбранные данные."); }
            }
            else { MessageBox.Show("Не все строки заполнены."); }
        }
        //Удаление товара
        private RelayCommand deleteProductWnd;
        public RelayCommand DeleteProductWnd
        {
            get
            {
                return deleteProductWnd ?? new RelayCommand(obj =>
                {
                    DeleteProductWndMethod();
                });
            }
        }
        public static void DeleteProductWndMethod()
        {
            using (var db = new TradeContext())
            {
                var productToDelete = db.Products.Find(SelectedProduct.ProductArticleNumber);
                if (productToDelete != null)
                {
                    if (productToDelete.ProductPhoto != null)
                    {
                        File.Delete(productToDelete.ProductPhoto);

                        db.Products.Remove(productToDelete);

                        db.SaveChanges();
                        MessageBox.Show("Товар удален.");
                        OpenAdminWndMethod();
                    }
                    else
                    {
                        db.Products.Remove(productToDelete);

                        db.SaveChanges();
                        MessageBox.Show("Товар удален.");
                        OpenAdminWndMethod();
                    }
                }
            }
        }
        //Все, что связно с менеджером
        private RelayCommand openManagerWnd;
        public RelayCommand OpenManagerWnd
        {
            get
            {
                return openManagerWnd ?? new RelayCommand(obj =>
                {
                    OpenManagerWndMethod();
                });
            }
        }
        public static void OpenManagerWndMethod()
        {
            Window currentWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            if (currentWindow != null)
            {
                currentWindow.Hide();
                Manager manager = new()
                {
                    Owner = Application.Current.MainWindow,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
                };
                manager.tUser.Text = fioUser;
                manager.ShowDialog();
                currentWindow.Close();
            }
        }
    }
}
