   M S B A M L   `   `   `  ����C  ?TestDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TestDemoTestDemo  5   	       TestDemo.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TestDemo     5   	     � Title$,  &ООО Цветы. Окно входа��5   	   $	��450��6'   $	��800��64    � Icon$C =C:\Users\Я\source\repos\TestDemo\TestDemo\Resources\icon.ico��6@    � WindowStartupLocation$ CenterScreen=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   �� ���	#FF76E383$��0��6%   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0��6.   $��Center=�6;   $��Center=�6X   .+�5      �� $C��=C:\Users\Я\source\repos\TestDemo\TestDemo\Resources\logo.png��6   $��80��6Z   $��80��6f   �� 5      $3��-ООО Цветы. Вход в систему��6   $
��Bold"�69   $��Center=�6K   $��30(�6f   $��15,0,0,0q�6t   5      �� 5   
   $ Vertical=�6   $��1��6,   $��Center=�69   $��Center=�6V   .+�5      �� $ 
Horizontal=�6   $��5q�62   .+�5      �� $��Логин: ��6   $	��150��6+   �� 5      -   5         ��Name$ tbLogin��5      $	��200��6+   5      �� 5      $ 
Horizontal=�6   $��5q�62   .+�5      �� $��Пароль: ��6   $	��150��6,   G� 5      -   5         G�Name$ 
tbPassword��5      $	��200��62   5      �� 5      $ 
Horizontal=�6   $��15q�62   $��Center=�6>   .+�5       �� -   5         ��Name$ bCancel��5       $��Отменить��6*   6=   �� 5!      -   5        $ bLogin��5!      $��
Войти��6)   $��10,0,0,0q�6N   5"      5#      �� 5$   
   ���	#FF76E383$��2��6%   5%      5&      