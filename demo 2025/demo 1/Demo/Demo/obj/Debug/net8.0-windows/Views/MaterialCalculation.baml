   M S B A M L   `   `   `  ����?  ;Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Demo.Views
Demo.Views  5      $    Demo.Views.MaterialCalculation   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Demo.Views     5        N� Title$  MaterialCalculation��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   .+�5   
   �� -   5         ��Name$ bBack��5      $��
Назад��6    $
��Left=�60   $��
10,41,0,42q�6K    
  Button#��[  6_   $��60��6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0��6.   $��Center=�6;   $��Center=�6V   .+�5      �� $:��4Расчет количества материала��6   $��22(�6;   $
��Bold"�6I   5      �� 5   
   $��3q�6   $��1��6%   $��Center=�62   $��Center=�6O    �� Padding$ 10q�6j   ���#F4E8D3._�5      �� $ Vertical=�6   $��Center=�60   $��Center=�6M   .+�5      �� $ 
Horizontal=�6   $��5q�66   .+�5      �� $0��*Выберите тип продукта: ��6    $	��150��6?   �� 5      -   5         ��Name$ cbProductType��5      $	��200��66   5      �� 5      $ 
Horizontal=�6   $��5q�66   .+�5      �� $)��#Выберите материал: ��6    $	��150��6;   �� 5      -   5        $ 
cbMaterial��5      $	��200��63   5      �� 5      $ 
Horizontal=�6   $��5q�66   .+�5      �� $/��)Количество продукции: ��6    $	��150��6>   �� 5       -   5         ��Name$ 
tbQuantity��5       $	��200��62   5!      �� 5"      $ 
Horizontal=�6   $��5q�66   .+�5#      �� $��Параметр 1: ��6    $	��150��64   �� 5$      -   5        $ tbParam1��5$      $	��200��60   5%      �� 5&      $ 
Horizontal=�6   $��5q�66   .+�5'      �� $��Параметр 2: ��6    $	��150��64   �� 5(      -   5        $ tbParam2��5(      $	��200��60   5)      �� 5*      -   5        $ 
bCalculate��5*      $��Расчитать��6-   #��[  6A   6a   5+      5,      5-      5.      