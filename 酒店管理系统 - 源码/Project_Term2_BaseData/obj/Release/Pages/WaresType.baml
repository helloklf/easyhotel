   M S B A M L   `   `   `  ���� Q  MProject_Term2_BaseData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MyControls
MyControls  ,    &Project_Term2_BaseData.Pages.WaresType   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'myclr-namespace:MyControls     -     >�Name$
  Main��$��20q� � 	Resources  �� Source�� $ ../Style.xaml?�%    .��]� $��Center=�$��Center=�$	��450��.+��� $��5q�$	��Top=�._��� -   $	��Tab��$��0q���Z� ��Z� .@��� $y�	Collapsed=�$��0q���Z� ��Z� .���� .+��� $��新增类型��$��18(�$��	0,10,10,0q����� *
Foreground+ �� ElementName$ C���� $��2��$	��Top=�$��0q�$��0,5,0,5q����� *
Background+$ C��]� $��5q�.+��� $��类型名称：��   	LeftTitle#��[  �� -    ��Name$ InText�� � ToolTip$0 *商品类型名(15字以内)，如'苹果'��  ShortTextBox#��[ ]� $��5q�.+��� $��备注说明*：��#��[  �� -   $ InRemark��$$ 备注信息（100字以内）��  LongTextBox#��[ ]� $��5q�.+��� $��商品图片*：��$0 *设定一张图片，以便轻松的识别��#��[  �� -    ��Name$ WI��$��54��$��96��$
��Left=�$; 5点击选择图片，建议使用54x96大小的图片��$��Image/图片.png��   MyControls.yes     MyControls.yes   	MouseDown$ Label_MouseDown���� $y�	Collapsed=�$��0q���Z� ��Z� .���� .+��� $��修改类型��$��18(�$��	0,10,10,0q����� *
Foreground+$ C���� $��2��$	��Top=�$��0q�$��0,5,0,5q����� *
Background+$ C��]� $��5q�.+��� $��类型名称：��#��[  �� -   $ UpText��$0 *商品类型名(15字以内)，如'苹果'��#��[ ]� $��5q�.+��� $��备注说明*：��#��[  �� -   $ UpRemark��$$ 备注信息（100字以内）��#��[ ]� $��5q�.+��� $��商品图片*：��$0 *设定一张图片，以便轻松的识别��#��[  �� -   $
 UpWI��$��54��$��96��$
��Left=�$5 /点击选择图片，建议分辨率96x54(16:9)����  �� Orientation$ 
Horizontal=�$��Right=�$��5q�.+�   MyControls.Back     MyControls.Back	   	MouseDown$	 
ReturnList��  $ Label_MouseDown_1��]� $	��Top=����#2000$��5q�.+��� .+��� -	   $ C��$y�	Collapsed=����� *	ForeColor+���� *	BgColor+�� -
   
 ��Name$
 IsCheck��$��5q����� *
Foreground+$ C��   MyControls.B     MyControls.B   	MouseDown$ SelectedItemEnabled��   MyControls.A     MyControls.A   	MouseDown$ SelectedItemEnabledNo���� -    ��Name$ LB��
������� �� SelectedValuePath$ WaresID������ .R��� .+��� $ 
Horizontal=�.+��� $��54��$��96��$��5q����� *
WaresImage+�� .+��� $ 
Horizontal=�$
��Left=�.+��� $��Center=�	编号：�� $��Center=� �� Padding$ 2q����� *	WaresID+�� $ 
Horizontal=�$
��Left=�.+��� $��Center=�有效性：�� $��Center=�$ 2q����� *	IsValid+�� $ 
Horizontal=�$
��Left=�.+��� $��Center=�商品类型：�� $��Center=�$ 2q����� *	WaresName+�� $ 
Horizontal=�.+��� $��Center=�类型备注：�� $��Center=�$
��Wrap=�$ 2q����� *WaresRemark+