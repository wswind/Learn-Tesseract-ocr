centos 7 


https://github.com/charlesw/tesseract/issues/503#issuecomment-613430901
https://github.com/charlesw/tesseract/issues/451
https://github.com/charlesw/tesseract/issues/451#issuecomment-447629060
https://www.cnblogs.com/dongyangblog/p/11177233.html
https://www.rpmfind.net/linux/rpm2html/search.php?query=tesseract

tesseract 3.05.02 and leptonica 1.75.3 

verion not right:
yum install epel-release
yum install tesseract-devel leptonica-devel


compile:

https://github.com/tesseract-ocr/tesseract/releases/tag/3.05.02
http://www.leptonica.org/source/leptonica-1.75.3.tar.gz

yum groupinstall "Development Tools"

tar -xzvf leptonica-..gz
cd leptonica-*
./configure --prefix=/usr/local/leptonica
make
sudo make install

vim /etc/profile


PKG_CONFIG_PATH=$PKG_CONFIG_PATH:/usr/local/leptonica/lib/pkgconfig
export PKG_CONFIG_PATH
CPLUS_INCLUDE_PATH=$CPLUS_INCLUDE_PATH:/usr/local/leptonica/include/leptonica
export CPLUS_INCLUDE_PATH
C_INCLUDE_PATH=$C_INCLUDE_PATH:/usr/local/leptonica/include/leptonica
export C_INCLUDE_PATH
LD_LIBRARY_PATH=$LD_LIBRARY_PATH:/usr/local/leptonica/lib
export LD_LIBRARY_PATH
LIBRARY_PATH=$LIBRARY_PATH:/usr/local/leptonica/lib
export LIBRARY_PATH
LIBLEPT_HEADERSDIR=/usr/local/leptonica/include/leptonica
export LIBLEPT_HEADERSDIR

https://tesseract-ocr.github.io/tessdoc/Compiling


./autogen.sh
./configure --prefix=/usr/local/tesseract
make
make install



find / -name "liblept*"
find / -name "libtesseract*.so*"

cd x64

ln -sf /usr/local/leptonica/lib/liblept.so.5.0.2 liblept1753.so
ln -sf /usr/local/tesseract/lib/libtesseract.so.3.0.5 libtesseract3052.so

https://blog.csdn.net/joe8910/article/details/84969195

