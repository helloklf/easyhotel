   M S B A M L   `   `   `  ���� Q  MProject_Term2_BaseData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MyControls
MyControls  .    (Project_Term2_BaseData.Pages.OperateType   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'myclr-namespace:MyControls     -   $��20q�  � 	Resources   �� Source�� $ ../Style.xaml?�%    .��]� $��Center=�$��Center=�$	��450��.+��� $��5q�$	��Top=�._��� -   $	��Tab��$��0q���Z� ��Z� .@��� $y�	Collapsed=�$��0q���Z� ��Z� .���� .+��� $	��Top=�$��新增类型��$��18(�$��	0,10,10,0q����� *
Foreground+ �� ElementName$ C���� $��2��$	��Top=�$��0,5,0,5q����� *
Background+$ C��]� $��2q�.+��� $��操作类型：��   	LeftTitle#��[  �� -   $��InText�� � ToolTip$5 /操作类型名(15字以内)，如:客户结账��  ShortTextBox#��[    MyControls.yes     MyControls.yes   	MouseDown$ Label_MouseDown���� $y�	Collapsed=�$��0q���Z� .���� .+��� $	��Top=�$��修改类型��$��18(�$��	0,10,10,0q����� *
Foreground+$ C���� $��2��$	��Top=�$��0,5,0,5q����� *
Background+$ C��]� $��2q�.+��� $��操作类型：��#��[  �� -   $��UpText��$5 /操作类型名(15字以内)，如:客户结账��#��[ ��  �� Orientation$ 
Horizontal=�$��Right=�$��5q�.+�   MyControls.Back     MyControls.Back   	MouseDown$ 
ReturnList��  $ Label_MouseDown_1��]� $	��Top=����#2000$��5q�.+��� $��Right=�.+��� -    ��Name$ C��$y�	Collapsed=����� *	ForeColor+���� *	BgColor+�� -    ��Name$ IsCheck��$��5q����� *
Foreground+$ C��   MyControls.B     MyControls.B	   	MouseDown$	 SelectedItemEnabled��   MyControls.A     MyControls.A
   	MouseDown$
 SelectedItemEnabledNo���� -    ��Name$ LB�� �� SelectedValuePath$ TypeID��
����������� .R��� .+��� $ 
Horizontal=�$y�Visible=�.+��� $ 
Horizontal=�$��Center=�.+��� $��Center=�	编号：�� $��Center=� �� Padding$ 2q����� *TypeID+�� $��20,0,0,0q�$ 
Horizontal=�$��Center=�.+��� $��Center=�有效性：�� $��Center=�$ 2q����� *	IsValid+�� $ 
Horizontal=�.+��� $��Center=�操作类型：�� $��Center=�$ 2q����� *OperateName+