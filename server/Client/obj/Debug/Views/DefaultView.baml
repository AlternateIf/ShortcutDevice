   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5   	       Client.Views.DefaultView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,Viewsclr-namespace:Client.Views     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   *ignorehttp://www.galasoft.ch/ignore  5   	     � DataContext  5
   	   �� *	Default+   Locator �� Source# [  .��5      �� 
����İ�$��0,2,0,0q�6*   ._�5   
   � $��20q�6    � RowDefinitions 5      �� 5      �� 5      .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� $��0��6   $��0,0,8,8q�6-   .+�5         Client.Views.CPUUsage  $��Center=�6%   $��Center=�6B      StrokeThickness$ 20��6]      SegmentColor
 �����   
Percentage$	 100Q�5   5   $��0,0,0,8q�6F      Radius$ 90��6W     5      $��Center=�6%   $��Center=�6B   $ 20��6]   
 � ���$ 90��5   �   $��
0,-229,0,8q�6�    61   �� *LeftUpperUsage+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�6�   �� 5      -   5        
 ��Name$
 	LeftUpper��5      $��23��62   $	��220��6>   ��6J   �� *	Processes+$ PropertyChanged=� �� SelectedItem 5      �� *LeftUpperProcess+$	 TwoWay=�$ PropertyChanged=���5      �� 5      .R�5   "   �� ��6,   �� *MainWindowTitle+$	 OneWay=�$ PropertyChanged=�5       ��5"      �� 5#       �� 
TargetType" ��6$   .�5$   "   ��  �� Property � �� �� Value$	 220��6:   5%      .  (System.Windows.Interactivity.Interaction   Triggers 5'      /  )System.Windows.Interactivity.EventTrigger  5(         	EventName$ SelectionChanged��6-   .  (System.Windows.Interactivity.TriggerBase   Actions. 5)   "   6  0System.Windows.Interactivity.InvokeCommandAction     Command 68   �� *LeftUpperProcessSelection+   CommandParameter 5*   4   ��  �� ElementName$ 	LeftUpper�� �� Path$ SelectedItem�5+      5-      �� 5.      $��
CPU-Anteil��6    $��
0,-150,0,0q�62   $��Center=�6F   $��16(�6c   5/      �� 50      $��1��6   $��8,0,0,8q�6-   .+�51        $��Center=�6%   $��Center=�6B   $ 20��6]   
 �����$	 100Q�52   5   $��0,0,0,8q�6F   $ 90��6W     53      $��Center=�6%   $��Center=�6B   $ 20��6]   
 � ���$ 90��54   X   $��
0,-229,0,8q�6d    61   �� *RightUpperUsage+6d   �� 55      -   5        $
 
RightUpper��55      $��23��63   $	��220��6?   ��6K   �� *	Processes+$ PropertyChanged=� 56      �� *RightUpperProcess+$	 OneWay=�$ PropertyChanged=���57      �� 58      .R�59   "   �� ��6,   �� *MainWindowTitle+$	 OneWay=�5:      ��5<      �� 5=      " ��6$   .�5>   "   ��  � ��$	 220��6:   5?       5A        5B      $ SelectionChanged��6-   . 5C   "      68   �� *RightUpperProcessSelection+ 5D   4   �� $ 
RightUpper��$ SelectedItem�5E      5G      �� 5H      $��
CPU-Anteil��6    $��
0,-150,0,0q�62   $��Center=�6F   $��16(�6c   5I      5J      � 5K      $��1��6    5L      �� 5M      $��* �6'   �� 5N      $��* �6'   .+�5P      �� $��0��6   $��0,8,8,0q�6-   .+�5Q        $��Center=�6%   $��Center=�6B   $ 20��6]   
 �����$	 100Q�5R   5   $��0,0,0,8q�6F   $ 90��6W     5S      $��Center=�6%   $��Center=�6B   $ 20��6]   
 � ���$ 90��5T   W   $��
0,-229,0,8q�6c    61   �� *LeftLowerUsage+6c   �� 5U      -   5        $
 	LeftLower��5U      $��23��62   $	��220��6>   ��6J   �� *	Processes+$ PropertyChanged=� 5V      �� *LeftLowerProcess+$	 OneWay=�$ PropertyChanged=���5W      �� 5X      .R�5Y   "   �� ��6,   �� *MainWindowTitle+$	 OneWay=�5Z      ��5\      �� 5]      " ��6$   .�5^   "   ��  � ��$	 220��6:   5_       5a        5b      $ SelectionChanged��6-   . 5c   "      68   �� *LeftLowerProcessSelection+ 5d   4   �� $ 	LeftLower��$ SelectedItem�5e      5g      �� 5h      $��
CPU-Anteil��6    $��
0,-150,0,0q�62   $��Center=�6F   $��16(�6c   5i      �� 5j      $��1��6   $��8,8,0,0q�6-   .+�5k        $��Center=�6%   $��Center=�6B   $ 20��6]   
 �����$	 100Q�5l   5   $��0,0,0,8q�6F   $ 90��6W     5m      $��Center=�6%   $��Center=�6B   $ 20��6]   
 � ���$ 90��5n   X   $��
0,-229,0,8q�6d    61   �� *RightLowerUsage+6d   �� 5o      -   5        $
 
RightLower��5o      $��23��63   $	��220��6?   ��6K   �� *	Processes+$ PropertyChanged=� 5p      �� *RightLowerProcess+$	 OneWay=�$ PropertyChanged=���5q      �� 5r      .R�5s   "   �� ��6,   �� *MainWindowTitle+$	 OneWay=�5t      ��5v      �� 5w      " ��6$   .�5x   "   ��  � ��$	 220��6:   5y       5{        5|      $ SelectionChanged��6-   . 5}   "      68   �� *RightLowerProcessSelection+ 5~   4   �� $ 
RightLower��$ SelectedItem�5      5�      �� 5�      $��
CPU-Anteil��6    $��
0,-150,0,0q�62   $��Center=�6F   $��16(�6c   5�      5�      5�      5�      5�      