using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace WindowsFormsApplication1
{

    #region "Dispose"

   // The following example demonstrates how to create
// a resource class that implements the IDisposable interface
// and the IDisposable.Dispose method.
    
    // A base class that implements IDisposable.
    // By implementing IDisposable, you are announcing that
    // instances of this type allocate scarce resources.
    public class MyResource: IDisposable
    {
        // Pointer to an external unmanaged resource.
        private IntPtr handle;
        // Other managed resource this class uses.
        private Component component = new Component();
        // Track whether Dispose has been called.
        private bool disposed = false;

        // The class constructor.
        public MyResource(IntPtr handle)
        {
            this.handle = handle;
        }

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if(!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if(disposing)
                {
                    // Dispose managed resources.
                    component.Dispose();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                CloseHandle(handle);
                handle = IntPtr.Zero;

                // Note disposing has been done.
                disposed = true;

            }
        }

        // Use interop to call the method necessary
        // to clean up the unmanaged resource.
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~MyResource()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
            
        }
    }

    public class BaseResource : IDisposable
    {
        ~BaseResource()
        {
            // 为了保持代码的可读性性和可维护性,千万不要在这里写释放非托管资源的代码 
            // 必须以Dispose(false)方式调用,以false告诉Dispose(bool disposing)函数是从垃圾回收器在调用 析构函数 时调用的 
            Dispose(false);
        }
        // 无法被客户直接调用 
        // 如果 disposing 是 true, 那么这个方法是被客户直接调用的,那么托管的,和非托管的资源都可以释放 
        // 如果 disposing 是 false, 那么函数是从垃圾回收器在调用Finalize时调用的,此时不应当引用其他托管对象所以,只能释放非托管资源 
        protected virtual void Dispose(bool disposing)
        {
            // 那么这个方法是被客户直接调用的,那么托管的,和非托管的资源都可以释放 
            if (disposing)
            {
                // 释放 托管资源
                //其它托管的类资源
                //OtherManagedObject.Dispose(); 
            }
            //释放非托管资源
            //非托管资源，一般想实现Close方法
            //DoUnManagedObjectDispose(); 
            // 那么这个方法是被客户直接调用的,告诉垃圾回收器从Finalization队列中清除自己,从而阻止垃圾回收器调用 析构函数 方法. 
            if (disposing)
                GC.SuppressFinalize(this);
        }
        //可以被客户直接调用 
        public void Dispose()
        {
            //必须以Dispose(true)方式调用,以true告诉Dispose(bool disposing)函数是被客户直接调用的 
            Dispose(true);
        }
    }

    public class MyClass : IDisposable
    {
        private bool disposed = false;
        ~MyClass()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed == false)
            {
                if (disposing == true)
                {
                    // 释托管代码
                    // ......
                }
                // 释非代码
                //......
            }
            disposed = true;
        }
    }

    #endregion

 







}
