   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      E AMyControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:MyControls;assembly=MyControls
MyControls 5       Project_Term2_Staff"   Project_Term2_Staff.StaffAdd   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6sys&clr-namespace:System;assembly=mscorlib     5      ;my,clr-namespace:MyControls;assembly=MyControls     5      -   5          � 	Resources  5       �� Source�� 5	   
   $ ../Style.xaml?�6   %    66   .��5      �� $	��450��6   $��Disabled=�6"   $��Hidden=�6K   $��Center=�6p   $��Center=�6�   .��5   
   �� .+�5      �� -   5         ��Name$ C��5      $y�	Collapsed=�6!   ��68   �� *	ForeColor+��6Y   �� *	BgColor+6z   �� 5      $��员工登记��6   $��25(�6$   $��	0,5,10,10q�62   ��6E   �� *
Foreground+ �� ElementName$ C��6w   ]� 5      $��5q�6   .+�5      �� $��员工姓名*：��6      	LeftTitle#��[  6*   6O   �� 5      -   5        $ InText��5       � ToolTip$ 员工姓名(15字以内)��6*     ShortTextBox#��[ 6@   5      �� 5      $��5q�6    �� Orientation$ 
Horizontal=�6$   $��35��6=   .+�5      �� $��性　　别*：��6   #��[  6*   6O   	� 5      -   5         	�Name$
 Sex1��5   S   $	��男��6   $��Center=�6*   $
��10,5q�6E    d� 	IsChecked$
 TrueY�6a   ��6r   �� *
Foreground+$ C����6�   �� *
Background+$ C��6�   	� 5      -   5        $
 Sex0��5   S   $	��女��6   $��Center=�6*   $
��10,5q�6E   ��6a   �� *
Foreground+$ C����6�   �� *
Background+$ C��6�   5      ]� 5      $��5q�6   .+�5      �� $��所属国家 ：��6   #��[  6*   6O   �� 5      -   5         ��Name$ InCouID��5      $��15(�6,   $��2q�6:   $��0q�6r   	 �� SelectedValuePath$	 	CountryID��6�   
 �� DisplayMemberPath$
 CountryName��6�   ��6E   Z� ��6[   Z� 6�   5      ]� 5!      $��5q�6   .+�5"      �� $��详细地址 ：��6   #��[  6*   6O   �� 5#      -   5        $ InAdress��5#   @   #��[ 6   6T   5$      ]� 5%      $��5q�6   .+�5&      �� $��身份证号*：��6   #��[  6*   6O   �� 5'      -   5        $ InCardID��5'      $$ 有效二代身份证证件号��6,   #��[ 6A    �� 	MaxLength$ 18��6g   5(      ]� 5*      $��5q�6   .+�5+      �� $��入职时间*：��6   #��[  6*   6O   (  "System.Windows.Controls.DatePicker  5,      -	   5          Name$ InInTime��5,      
 �� Now   SelectedDate# Z 6/   6\   5-      ]� 5/      $��5q�6   .+�50      �� $��员工头像：��6   #��[  6)   6N   �� 51      -
   5         ��Name$ InHeader��51   J   $��40��6   $��96��6$   $
��Left=�6/   $9 3为职工选择一个头像(推荐分辨率240x320)��6\   $��pages/Image/图片.png��6~   6�   52      ]� 54      $��5q�6   .+�55      �� $��手机号码：��6   #��[  6)   6N   �� 56      -   5        $ InTel��56      $( "员工的联系方式(20字以内)��6)   #��[ 6B   57      ]� 59      $��5q�6   �� 5:      $��Right=�6   $ 
Horizontal=�65   .+�5;        MyControls.No  -   5        5;   0     MyControls.OK  5<      -   5        $
��10,5q�5<   4   6D   5=      5>      5?      5A      