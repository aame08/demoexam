   M S B A M L   `   `   `  ����@  <Demka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Demka.ViewsDemka.Views  5   	       Demka.Views.Cart   5   	   Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Demka.Views     5   	     � Title$  Пиши-стирай��5   	   $	��480��6   $	��800��6*    � Icon$= 7C:\Users\Я\source\repos\Demka\Demka\Resources\icon.ico��66    � WindowStartupLocation$ CenterScreen=�6t   $	��480��6�   $	��800��6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��5 �6   �� 5      $
��250* �6   �� 5      $	��50* �6   �� 5      $��5 �6   �� 5      $��50 �6   .+�5   
   �� $��0��6   $��2��6!   $��2��62   ���	#FF76E3836F   �� 5   
   -   5         ��Name$ bExit��5      $��Закрыть��6    $��30��62    
  Button#��[  6>   $��60��6^   $��	10,12,0,0q�6i   $
��Left=�6|   $	��Top=�6�   ��6�   �� *OpenViewProductWnd+� 5   
    � Orientation$ 
Horizontal=�6   $��0��6-   $��2��6;   $��Center=�6O   $��Center=�6l   .+�5      �� $8��2C:\Users\Я\source\repos\Demo\Demo\Images\logo.png��6   �� 5      $+��%ПИШИ-СТИРАЙ. Корзина��6     MainText#��[ 64   5      �� 5   
   -   5         ��Name$
 list��5      $��Center=�6!   $��Disabled=�6>   $��2��6�   $��0��6�   $��2��6�   ��6t   Z� ��5      �� 5      .R�5      � 5       5"      � 5#   
   $ 
Horizontal=�6   $��Center=�6-   $��Center=�6J   $��3��6e   $��0��6r   $��2��6�   .+�5$      �� $��Пункт выдачи: ��6     Text#��[ 6.   �� 5%      -   5         ��Name$ cbPoint��5%      $��20��6(   $	��150��64     ComboBox#��[ 6@   ��6b   �� *PickupPointList+5&      �� 5'   
   $��4��6   $��2��6!   $��2��62   ���	#FF76E3836F   � 5(   
   $ 
Horizontal=�6   $��5��6-   $��0��6:   $��2��6J   $��Center=�6^   $��Center=�6{   .+�5)      � $ 
Horizontal=�6   $��10q�61   .+�5*      �� $+��%Количество товаров: ��6   #��[ 68   �� 5+      -   5        	 ��Name$	 tCount��5+      $��1��6,   #��[ 65   5,      � 5-      $ 
Horizontal=�6   $��10q�61   .+�5.      �� $%��Общая стоимость: ��6   #��[ 65   �� 5/      -   5        $	 tPrice��5/      $��1��6,   #��[ 65   �� 50      $�� р. ��6   #��[ 6(   �� 51      -   5        $ bOrder��51      $��Заказать��6)   #��[  6<   ��6\   �� *OpenTicketWnd+52      53      54      55      