   M S B A M L   `   `   `  ����A  =TETRIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TETRISTETRIS  5   	       TETRIS.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:TETRIS     5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)   $	��600��5	   	   $	��600��6   
�������$��Liberation Mono)�5   	   $��32(�6&   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   ��5   
   �� 5       �� ImageSource$ Assets/Background.png��6   .+�5   
   (� $��1��6   $��1��6   $��20,20,20,20q�6/   .��5      �� -   5         ��Name$ 
GameCanvas��5      ���#101010$	��250��5       $	��500��5!      $
}�True��5"      5#      5$      �� 5&   
   -   5         ��Name$ 	ScoreText��5&      $��0��5'      $��1��5(      $��Score ��5)      $
��0,10q�5*       �� TextAlignment$ Center=�5+      �� 5-   
   $��1��6   $��0��5.      $��Center=�5/      $��Right=�50      51      �� 53   
   $��1��6   $��2��6"   $��Center=�62   $
��Left=�6M   .+�54      �� $
��Next��6   $ Center=�55      �� 57      -   5         ��Name$ 	NextImage��57      $��20q�58      $	��125��59      5:      � 5<   
   -   5         �Name$ GameOverMenu��5<      ���	#CC000000$��2��5>      $��3��5?      $y�Hidden=�5@      .+�5A      �� $��Center=�6   $��Center=�5B      .+�5C      �� $��Rest in pelce brah��6   $��48(�5D      $ Center=�5E      $��64��6/   �� 5F      -   5        $ FinalScoreText��5F      $��Final Score : ��5G      $��36(�5H      $ Center=�5I      $��32��64   �� 5J      $��Assets/rip-brah-1.png��6   $	��372��67   $	��372��6D   $��16,16,16,16q�6P   �� 5K      -   5        $��	Go Again?��5K      ���#44DDAA���#113322$��16,16,16,16q�5N      $	��369��5O      5P      5Q      5R      5S      5T      