   M S B A M L   `   `   `  ����@  <Demo3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Demo3.ViewsDemo3.Views  5          Demo3.Views.UCProduct   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Demo3.Views     5        � 	Resources  5	         DiscountStyle �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value��%�   &	        �� 5
   
   " �6&    5      �� 5       6   �� *
NowDicount+ 156=   .a�5      ��  � �� �#7fff0063   5      5      5      .��5      � #��[  6   .+�5   
   �� ���	#FF498C51$��1q�6)    �� CornerRadius$ 3��6=   ._�5      � 
������� � ColumnDefinitions 5      �� 5      $��2* �6'   �� 5      $��3* �6'   �� 5      $��* �6'   .+�5      �� $��0��6:   $��Center=�6J   $��Stretch=�6e   $	��150��6�   $	��150��6�   ��6   �� *DisplayedImage+6�   �� 5      	 �� Orientation$	 Vertical=�6   $��1��64   $��Center=�6D   $��Stretch=�6_   $	��450��6}   .+�5      �� -   5        
 ��Name$

 tbID��5       $��1(�6I   ��6.   �� *	IdProduct+6I   �� 5      -   5        $
 tbName��5       $��18(�6M   $
��Bold"�6[   ��60   �� *NameProduct+6[   �� 5      -   5        $
 tbDescription��5       $��16(�6T   $��WrapWithOverflow=�6b   ��67   �� *DescProduct+6b   �� 5      -   5        $
 tbManufacturer��5       $��16(�6o   ��68   �� *'%IdManufacterNavigation.NameManufacter+6o   �� 5       -   5        $
 tbCost��5        $��16(�60   
�5!      �� 5"       �� TextDecorations$ Strikethrough{�6\   �6"   �� *CostProduct+ �� StringFormat$ C�� �� Mode$ OneWay=�6\    �� 5#      �6"   �� *DisplayedPrice+$ C��$ OneWay=�5%      5&      �� 5'      -   5        $
 
tbDiscount��5'      $�� ��60   $��2��68   $��16(�6H   $��Center=�6V   $��Center=�6s   
�5(      �� 5)      �6   �� *
NowDicount+ �� 5*      $�%��6   5,      5-      5.      5/      50      