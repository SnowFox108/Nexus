ctr = 0;
for (x in threads)
{
  document.writeln("<a href=\"showthread.php?t="+threads[x].threadid+"\">"+threads[x].title+"</a><br />");
ctr++;
if (ctr == 8) 
  {
     break;
  }
}