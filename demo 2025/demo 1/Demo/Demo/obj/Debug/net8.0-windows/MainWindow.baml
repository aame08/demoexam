   M S B A M L   `   `   `  ����?  ;Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DemoDemo  5   	       Demo.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Demo     5   	     � Title$  Главная форма��5   	   $	��600��6   $	��800��6,    � Icon$ /Мастер пол.ico��68    � WindowStartupLocation$ CenterScreen=�6O   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $��3* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��1��6;   $��Center=�6K   $��Center=�6h   .+�5      �� $����C:\Users\Я\Desktop\UKSIVT\demo\КОД 09.02.07-2-2025 Приложения к образцу задания Том 1\Ресурсы\Мастер пол.png��6   $��80��6�   �� 5      $��Мастер пол��6   $��Center=�6*   $��28(�6E   $
��Bold"�6S   $��25, 0, 0, 0q�6e   5      � 5   
   $��1��6   $��3��6   $��
15,0,15,15q�60    5      �� 5      $��1* �6    �� 5      $��3* �6    .+�5      �� $��0��6   $ 
Horizontal=�6&   $��Center=�6?   .+�5      �� $)��#Просмотр партнеров��6   ���#67BA80$
��Bold"�6K   $��22(�6]   $��Center=�6k   $��Center=�6�   �� 5      -   5         ��Name$
 bAdd��5      $'��!Добавить партнера��6'    
  Button#��[  6C   $��10, 0, 0, 0q�6c   $	��120��6�   �� 5       -   5        $ bHistory��5       $!��История продаж��6+   #��[  6D   $��10, 0, 0, 0q�6d   $	��120��6�   �� 5!      -   5        $ bCalculation��5!      $��Расчет��6/   $��10, 0, 0, 0q�6@   #��[  6U   $��50��6�   5"      �� 5#      -   5         ��Name$ PartnersListView��5#      ���#F4E8D3$��Segoe UI)�6F   $��Stretch=�6\   $��1��6z   ��5$      �� 5%      .R�5&      �� 5'      5)      5*       � 5+   
   -   5          �Name$ frame��5+      $��1��6   $��0��6,   $��3��6<   $y�Hidden=�6P   	  � NavigationUIVisibility$	 Hidden=�6d   
  � JournalOwnership$
 OwnsJournal=�6�   5,      5-      