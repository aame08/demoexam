   M S B A M L   `   `   `  ����@  <Demka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Demka.ViewsDemka.Views  5          Demka.Views.ProductCard   5      Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Demka.Views     5      .��5	      � .+�5
   
   �� ���#498C51$��1q�6'     �� CornerRadius$  3��6;   ._�5      � 
������� � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $��3* �6'   64   �� 5      $��* �6'   63   .+�5      �� $��0��6   $��Center=�6J   $��Center=�6e   $	��125��6�   $	��125��6�   ��6(   �� *DisplayedImage+6�   � 5      $��1��6   $��Center=�6'    � RowDefinitions 5      �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   .+�5      �� $��0��6    $
��Bold"�6-   ��6?   �� *ProductName+�� 5      $��1��6    $
��Wrap=�6Q   ��6-   �� *ProductDescription+6Q   �� 5      $��2��6    $
��Wrap=�6   ��6-   �� *Manufacturer.ManufacturerName+ �� StringFormat$% Производитель: {0}��6   �� 5      $��3��6    $
��Wrap=�6-   
�5      �� 5      $�	Цена:��6"    �� 5       �6"   �� *ProductCost+$ {0:C}�� �� ConverterCulture$ ru-RU��5"      �� 5#      $��4��6    $
��Wrap=�6-   �� 5$      $#�Цена со скидкой:��6    �� 5%      �6   �� *DisplayedPrice+$ {0:C}��$ ru-RU�� �� Mode$ OneWay=�5&      5'      � 5(      $��2��6   $��Center=�6,    � Orientation$ Vertical=�6G   .+�5)      �� $
��Wrap=�6d   ��6    �� *ProductDiscountAmount+$ Скидка: {0}%��6d   �� 5*      $
��Wrap=�6    �� 5+      $�В наличии:��6    �� 5,      �6   �� *ProductQuantityInStock+ �� 5-      �6   �� *ProductUnit+5.      5/      50      51      52      53      