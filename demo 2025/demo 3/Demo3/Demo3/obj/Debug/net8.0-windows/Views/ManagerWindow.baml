   M S B A M L   `   `   `  ����@  <Demo3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Demo3.ViewsDemo3.Views  5   	       Demo3.Views.ManagerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Demo3.Views     5   	     � Title$<  6ООО Украшение. Окно менеджера��5   	   $	��450��6/   $	��800��6<    � Icon$= 7C:\Users\Я\source\repos\Demo3\Demo3\Resources\icon.ico��6H    � WindowStartupLocation$ CenterScreen=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��4* �6   �� 5      $��1 �6   .+�5   
   �� ���	#FFFFCC97$��0��6%   $��2��62   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0��6.   $��Center=�6;   .+�5      �� $=��7C:\Users\Я\source\repos\Demo3\Demo3\Resources\logo.png��6   �� 5      $��OOO Украшение��6   $��Center=�6-   $��Center=�6J   $��30(�6e   5      �� 5   
   -   5         ��Name$ bBack��5      $��
Назад��6    $��1��60   $
��Left=�6=   $	��Top=�6X   $��5,10,0,0q�6p   6�   �� 5   
   -   5         ��Name$ 
tbNameUser��5      $��1��6(   $��16(�65   $��Right=�6C   $	��Top=�6_   $��0,0,5,0q�6w   �� 5   
   $ 
Horizontal=�6   $��1��6.   $��Bottom=�6;   .+�5      �� $��Фильтрация: ��6   $��15,0,0,0q�6,   �� 5      -   5         ��Name$ cbFilter��5      $	��160��6)   65   �� 5      $��Сортировка: ��6   $��15,0,0,0q�6,   �� 5      -   5        $ cbSort��5      $	��160��6'   63   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgOrders��5      $��2��6%   	   AutoGenerateColumns$	 False��62   
   SelectionMode$
 Single=�6N      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      
IsReadOnly$
 True��6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	IdOrder+6M     5       $ Дата заказа��6%    6:   �� *	DateOrder+ �� StringFormat$ {0:dd/MM/yyyy}��  5!      $ Дата доставки��6%    6<   �� *DateDeliverOrder+$ {0:dd/MM/yyyy}��  5"      $ ФИО клиента��6%    6:   �� *FIO+  5#      $( "Общая сумма заказа��6%    6A   �� *TotalAmount+$ {0:C}��  5$      $* $Общая скидка заказа��6%    6B   �� *TotalDiscount+$ {0:P}��  5%      $ Статус��6%    65   �� *StatusOrder+5'      5(      5)      