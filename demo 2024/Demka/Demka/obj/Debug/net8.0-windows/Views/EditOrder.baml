   M S B A M L   `   `   `  ����@  <Demka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Demka.ViewsDemka.Views  5   	       Demka.Views.EditOrder   5   	   Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Demka.Views     5   	     � Title$  Пиши-стирай��5   	   $	��450��6   $	��800��6*    � Icon$= 7C:\Users\Я\source\repos\Demka\Demka\Resources\icon.ico��66    � WindowStartupLocation$ CenterScreen=�6t   $	��450��6�   $	��800��6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $	��390 �6   �� 5      $	��390 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $
��250* �6   �� 5      $	��35* �6   �� 5      $��30 �6   .+�5   
   �� -   5         ��Name$ bExit��5      $��Закрыть��6    $��0��62   $��1��6?   $
��Left=�6O    
  Button#��[  6j   $��50��6�   $��20��6�   $��10q�6�   $��Center=�6�   ��6�   �� *OpenAdminWnd+�� 5   
   $P��JЗаполните поля, которые хотите изменить.��6     Text#��[ 6D   $��0��6b   $��1��6o   $��2��6   �� 5   
   $��1��6   $��1��6"   $��Center=�62   $��Center=�6O   .+�5      �  � Orientation$ 
Horizontal=�6   $��2q�61   .+�5      �� $��Номер заказа:��6     TBl_for_crud#��[ 61   $��5q�6W   �� 5      -   5         ��Name$ 	tbOrderId��5        TB_for_crud#��[ 6-   $��10q�6R    �� 
IsReadOnly$
 True��6^   5      � 5      $ 
Horizontal=�6   $��2q�61   .+�5      �� $��Дата заказа:��6   #��[ 60   $��5q�6V   �� 5      -   5        $ tbOrderDate��5      #��[ 6/   $��10q�6T   $
 True��6`   5       � 5!      $ 
Horizontal=�6   $��2q�61   .+�5"      �� $ ��Дата доставки:��6   #��[ 62   $��5q�6X   �� 5#      -   5        $ tbOrderDeliveryDate��5#      #��[ 67   $��10q�6\   5$      � 5%      $ 
Horizontal=�6   $��2q�61   .+�5&      �� $��Пункт выдачи:��6   #��[ 61   $��5q�6W   �� 5'      -   5        $ tbPickupPoint��5'      #��[ 61   $��10q�6V   5(      � 5)      $ 
Horizontal=�6   $��2q�61   .+�5*      �� $��Клиент:��6   #��[ 6+   $��5q�6Q   �� 5+      -   5        $ tbOrderClient��5+      #��[ 61   $��10q�6V   $
 True��6b   5,      � 5-      $ 
Horizontal=�6   $��2q�61   .+�5.      �� $ ��Код получения:��6   #��[ 62   $��5q�6X   �� 5/      -   5        $ tbRecieveCode��5/      #��[ 61   $��10q�6V   $
 True��6b   50      � 51      $ 
Horizontal=�6   $��2q�61   .+�52      �� $ ��Статус заказа:��6   #��[ 62   $��5q�6X   �� 53      -   5        	 ��Name$	 cbOrderStatus��53        ComboBox#��[ 62   $	��150��6T   $��20��6`   $��10q�6l   ��6x   �� *OrderStatuses+54      55      �� 56   
   $��1��6   $��2��6"   $��Center=�62   $��Center=�6O   .+�57      �� $ ��Состав заказа:��6   #��[ 6.   $��5q�6T   &   System.Windows.Controls.DataGrid  58      -	   5        
  Name$
 dgOrderProduct��58         AutoGenerateColumns$ False��6/      SelectionMode$ Single=�6K      SelectionUnit$ FullRow=�6b      
IsReadOnly$
 True��6z   
�������   RowBackground
 �����   Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заказа��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *	OrderId+   HeaderStyle 5;      �� 5<       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�5=   "   ��  �� Property � �� �� Value �	#FF76E3836?   5>      5@        5A      $! Артукул товара��6)   $ 1* 6j    6A   �� *ProductArticleNumber+ 5B      �� 5C      "  6$   .�5D   "   ��  � �� �	#FF76E3836?   5E      5G        5H      $' !Количество товара��6)   $ 1* 6a    6D   �� *
Quantity+ 5I      �� 5J      "  6$   .�5K   "   ��  � �� �	#FF76E3836?   5L      5N      5P      5Q      � 5R   
   $ 
Horizontal=�6   $��2��6-   $��1��6:   $��2��6J   $��Center=�6^   $��Center=�6{   .+�5S      �� -
   5        $ bEdit��5S      $��Изменить��6$   #��[  67   $��20��6W   $��10q�6w   5T      5U      5V      