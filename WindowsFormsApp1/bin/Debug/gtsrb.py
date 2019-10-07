import clr
clr.AddReference('System.Windows.Forms')
from System.Windows.Forms import*
name='GTSRB'

def RunIme_Click(sender, args):
    
    txt1=str((sender.Tag.lbl4.Text))
    lst=txt1.split(':')
    a1=float(lst[1])
    a2=float(lst[2])
    sender.Tag.lbl4.Text="30:"+str(a1/a2)

    txt2=(sender.Tag.lbl3.Text)
    lst1=txt2.split(':')
    b1=float(lst1[1])
    b2=float(lst1[2])
    sender.Tag.lbl3.Text="20:"+str(b1/b2)

    txt3=(sender.Tag.lbl5.Text)
    lst2=txt3.split(':')
    c=float(lst2[1])
    c2=float(lst2[2])
    sender.Tag.lbl5.Text="50:"+str(c/c2)

    txt4=(sender.Tag.lbl6.Text)
    lst3=txt4.split(':')
    d=float(lst3[1])
    d2=float(lst3[2])
    sender.Tag.lbl6.Text="60:"+str(d/d2)

    txt5=(sender.Tag.lbl7.Text)
    lst4=txt5.split(':')
    e=float(lst4[1])
    e2=float(lst4[2])
    sender.Tag.lbl7.Text="70:"+str(e/e2)

    txt6=(sender.Tag.lbl8.Text)
    lst5=txt6.split(':')
    f=float(lst5[1])
    f2=float(lst5[2])
    sender.Tag.lbl8.Text="80:"+str(f/f2)

    txt7=(sender.Tag.lbl9.Text)
    lst7=txt7.split(':')
    e3=float(lst7[1])
    e4=float(lst7[2])
    sender.Tag.lbl9.Text="90:"+str(e3/e4)

    txt8=(sender.Tag.lbl10.Text)
    lst8=txt8.split(':')
    e5=float(lst8[1])
    e6=float(lst8[2])
    sender.Tag.lbl10.Text="100:"+str(e5/e6)

    txt9=(sender.Tag.lbl12.Text)
    lst9=txt9.split(':')
    e7=float(lst9[1])
    e8=float(lst9[2])
    sender.Tag.lbl12.Text="120:"+str(e7/e8)


def LoadExtension(frm):
    RunIme=ToolStripMenuItem(Name=name, Text='&GTSRB')
    RunIme.Click += RunIme_Click
    RunIme.Tag=frm
    frm.addedToolStripMenuItem.DropDownItems.Add(RunIme)



   





