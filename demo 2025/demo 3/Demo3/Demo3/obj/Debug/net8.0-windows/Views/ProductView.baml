   M S B A M L   `   `   `  ����@  <Demo3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Demo3.ViewsDemo3.Views  5   	       Demo3.Views.ProductView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Demo3.Views     5   	     � Title$@  :ООО Украшение. Просмотр товаров��5   	   $	��450��61   $	��800��6>    � Icon$= 7C:\Users\Я\source\repos\Demo3\Demo3\Resources\icon.ico��6J    � WindowStartupLocation$ CenterScreen=�6�   .��5	      �  � RowDefinitions 5
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
Horizontal=�6   $��1��6.   $��Bottom=�6;   .+�5      �� $��Поиск: ��6   �� 5      -   5         ��Name$ tbSearch��5      $	��160��6(   64   �� 5      $��Фильтрация: ��6   $��15,0,0,0q�6,   �� 5      -   5         ��Name$ cbFilter��5      $	��160��6)   65   �� 5      $��Сортировка: ��6   $��15,0,0,0q�6,   �� 5      -   5        $ cbSort��5      $	��160��6'   63   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   $��Right=�6;   .+�5       �� -   5        $ tbCurrentCount��5       �� 5!      $�� из ��6   �� 5"      -   5        $ 
tbAllCount��5"      5#      �� 5$   
   -   5        	 ��Name$	 
lvProducts��5$      $��2��6'   $��0,20,0,0q�64   $��Stretch=�6F   $��Stretch=�6d   $��Disabled=�6�   ��5%      �� 5&      .R�5'      �� $ Vertical=�6!   5(      5*      5+      5,      