   M S B A M L   `   `   `  ����?  ;Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Demo.Views
Demo.Views  5   	        Demo.Views.EditApplication   5   	   Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Demo.Views     5   	     � Title$  Техносервис��5   	   $	��300��6   $	��400��6*    � Icon$; 5C:\Users\Я\source\repos\Demo\Demo\Resources\logo.png��66    � WindowStartupLocation$ CenterScreen=�6r   $	��300��6�   $	��400��6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $	��190 �6   �� 5      $	��190 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $
��250* �6   �� 5      $	��35* �6   .+�5   
   �� -   5         ��Name$ bExit��5      $��Закрыть��6    $��0��62   $��0��6?   $��2��6O   $
��Left=�6c    
  Button#��[  6~   $��50��6�   $��20��6�   $��10q�6�   $��Center=�6�   ��6�   �� *OpenAdminWnd+�� 5   
   $5��/Изменение статуса заявки.��6     Text#��[ 65   $��0��6S   $��1��6`   $��2��6p   �� 5   
   $��1��6   $��1��6"   $��2��62   $��Center=�6F   $��Center=�6c   .+�5      �  � Orientation$ 
Horizontal=�6   $��2q�61   .+�5      �� $��Номер заявки:��6     TBl_for_crud#��[ 61   $��5q�6W   �� 5      -   5         ��Name$
 tbID��5        TB_for_crud#��[ 6(   $��10q�6M   $	��150��6Y   5      � 5      $ 
Horizontal=�6   $��2q�61   .+�5      �� $��Исполнитель:��6   #��[ 60   $��5q�6V   �� 5      -   5         ��Name$ cbPermormer��5        ComboBox#��[ 60   $��20��6R   $	��150��6^   $��10q�6�   ��6j   �� *PerformersList+6�   5      � 5       $ 
Horizontal=�6   $��2q�61   .+�5!      � $ 
Horizontal=�6   $��2q�65   .+�5"      �� $��Статус:��6    #��[ 6/   $��5q�6U   �� 5#      -   5        $ cbStatus��5#      #��[ 61   $��20��6S   $	��150��6_   $��10q�6�   ��6k   �� *
StatusList+6�   5$      5%      � 5&      $ 
Horizontal=�6   $��Center=�61   $��Center=�6N   .+�5'      �� -   5        $ bEdit��5'      $��Изменить��6(   #��[  6;   $��20��6[   $��10q�6g   ��6s   �� *EditApplicationWnd+5(      5)      5*      5+      