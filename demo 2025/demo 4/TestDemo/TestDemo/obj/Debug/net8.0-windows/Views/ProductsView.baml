   M S B A M L   `   `   `  ����C  ?TestDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TestDemo.ViewsTestDemo.Views  5   	   !    TestDemo.Views.ProductsView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TestDemo.Views     5   	     � Title$8  2ООО Цветы. Просмотр товаров��5   	   $	��450��6-   $	��900��6:    � Icon$C =C:\Users\Я\source\repos\TestDemo\TestDemo\Resources\icon.ico��6F    � WindowStartupLocation$ CenterScreen=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��1 �6   .+�5   
   �� ���	#FF76E383$��0��6%   $��2��62   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0��6.   $��Center=�6;   $��Center=�6X   .+�5      �� $C��=C:\Users\Я\source\repos\TestDemo\TestDemo\Resources\logo.png��6   $��80��6Z   $��80��6f   �� 5      $8��2ООО Цветы. Просмотр товаров��6   $
��Bold"�6;   $��Center=�6M   $��30(�6h   $��15,0,0,0q�6v   5      �� 5   
   $ 
Horizontal=�6   $	��Top=�6.   $��Stretch=�6F   $��1��6d   .+�5      �� -   5         ��Name$ bBack��5      $��
Назад��6$   64   �� 5      -   5         ��Name$ tbName��5      5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��Center=�6I   $��1��6f   .+�5      �� $(��"Поиск по названию: ��6   �� 5      -   5         ��Name$ tbSearch��5      $	��150��6(   64   �� 5      $*��$Сортировка по цене: ��6   $��10,0,0,0q�64   �� 5       -   5         ��Name$ cbSort��5       $	��150��6'   63   �� 5!      $��Фильтрация: ��6   $��10,0,0,0q�6,   �� 5"      -   5        $ cbFilter��5"      $	��150��6)   65   5#      �� 5%   
   -   5        	 ��Name$	 
lvProducts��5%      $��2��6'   $��Stretch=�64   $��Center=�6R   $��Disabled=�6m   $��Stretch=�6�   ��5&      �� 5'      .R�5(      � 
 � Orientation$
 Vertical=�6    5)      5+      5,      5-      