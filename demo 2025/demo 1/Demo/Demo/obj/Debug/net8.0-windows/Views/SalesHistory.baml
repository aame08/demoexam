   M S B A M L   `   `   `  ����?  ;Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Demo.Views
Demo.Views  5          Demo.Views.SalesHistory   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Demo.Views     5        N� Title$  SalesHistory��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��3* �6   .+�5   
   �� -   5         ��Name$ bBack��5      $��
Назад��6    $��
5, 0, 0, 0q�60   $
��Left=�6D    
  Button#��[  6_   $��50��6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0��6.   $��Center=�6;   $��Center=�6V   .+�5      �� $6��0Просмотр продаж партнеров��6   $��22(�69   $
��Bold"�6G   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgProducts��5      $��1��6'   $��Stretch=�64   $��Stretch=�6R      AutoGenerateColumns$ False��6n      SelectionMode$ Single=�6�      SelectionUnit$ FullRow=�6�      
IsReadOnly$
 True��6�   ���#F4E8D3	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *IdPartnersProducts+6X     5      $1
 +Наименование продукции��6%   $ 2* 6~    6E   �� *&$ArticleProductNavigation.NameProduct+6~     5      $"
 Количество (шт.)��6%   $ 2* 6`    6?   �� *CountProduct+6`     5      $
 Дата продажи��6%   $ 2* 6X    6;   �� *
DateSale+6X   5      5      5      