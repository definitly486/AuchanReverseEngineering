package androidx.work.multiprocess;

import android.os.Binder;
import android.os.IBinder;
import android.os.IInterface;
import android.os.Parcel;

/* JADX INFO: loaded from: classes.dex */
public interface IWorkManagerImpl extends IInterface {
    public static final String DESCRIPTOR = "androidx$work$multiprocess$IWorkManagerImpl".replace('$', '.');

    public static class Default implements IWorkManagerImpl {
        @Override // android.os.IInterface
        public IBinder asBinder() {
            return null;
        }

        public void cancelAllWork(IWorkManagerImplCallback iWorkManagerImplCallback) {
        }

        public void cancelAllWorkByTag(String str, IWorkManagerImplCallback iWorkManagerImplCallback) {
        }

        public void cancelUniqueWork(String str, IWorkManagerImplCallback iWorkManagerImplCallback) {
        }

        public void cancelWorkById(String str, IWorkManagerImplCallback iWorkManagerImplCallback) {
        }

        public void enqueueContinuation(byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback) {
        }

        public void enqueueWorkRequests(byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback) {
        }

        public void queryWorkInfo(byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback) {
        }

        public void setForegroundAsync(byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback) {
        }

        public void setProgress(byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback) {
        }

        public void updateUniquePeriodicWorkRequest(String str, byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback) {
        }
    }

    public static abstract class Stub extends Binder implements IWorkManagerImpl {
        @Override // android.os.IInterface
        public IBinder asBinder() {
            return this;
        }

        public abstract /* synthetic */ void cancelAllWork(IWorkManagerImplCallback iWorkManagerImplCallback);

        public abstract /* synthetic */ void cancelAllWorkByTag(String str, IWorkManagerImplCallback iWorkManagerImplCallback);

        public abstract /* synthetic */ void cancelUniqueWork(String str, IWorkManagerImplCallback iWorkManagerImplCallback);

        public abstract /* synthetic */ void cancelWorkById(String str, IWorkManagerImplCallback iWorkManagerImplCallback);

        public abstract /* synthetic */ void enqueueContinuation(byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback);

        public abstract /* synthetic */ void enqueueWorkRequests(byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback);

        public abstract /* synthetic */ void queryWorkInfo(byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback);

        public abstract /* synthetic */ void setForegroundAsync(byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback);

        public abstract /* synthetic */ void setProgress(byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback);

        public abstract /* synthetic */ void updateUniquePeriodicWorkRequest(String str, byte[] bArr, IWorkManagerImplCallback iWorkManagerImplCallback);

        public Stub() {
            attachInterface(this, IWorkManagerImpl.DESCRIPTOR);
        }

        public static IWorkManagerImpl asInterface(IBinder iBinder) {
            if (iBinder == null) {
                return null;
            }
            IInterface iInterfaceQueryLocalInterface = iBinder.queryLocalInterface(IWorkManagerImpl.DESCRIPTOR);
            if (iInterfaceQueryLocalInterface != null && (iInterfaceQueryLocalInterface instanceof IWorkManagerImpl)) {
                return (IWorkManagerImpl) iInterfaceQueryLocalInterface;
            }
            return new Proxy(iBinder);
        }

        @Override // android.os.Binder
        public boolean onTransact(int i, Parcel parcel, Parcel parcel2, int i2) {
            String str = IWorkManagerImpl.DESCRIPTOR;
            if (i >= 1 && i <= 16777215) {
                parcel.enforceInterface(str);
            }
            if (i == 1598968902) {
                parcel2.writeString(str);
                return true;
            }
            switch (i) {
                case 1:
                    enqueueWorkRequests(parcel.createByteArray(), IWorkManagerImplCallback.Stub.asInterface(parcel.readStrongBinder()));
                    return true;
                case 2:
                    updateUniquePeriodicWorkRequest(parcel.readString(), parcel.createByteArray(), IWorkManagerImplCallback.Stub.asInterface(parcel.readStrongBinder()));
                    return true;
                case 3:
                    enqueueContinuation(parcel.createByteArray(), IWorkManagerImplCallback.Stub.asInterface(parcel.readStrongBinder()));
                    return true;
                case 4:
                    cancelWorkById(parcel.readString(), IWorkManagerImplCallback.Stub.asInterface(parcel.readStrongBinder()));
                    return true;
                case 5:
                    cancelAllWorkByTag(parcel.readString(), IWorkManagerImplCallback.Stub.asInterface(parcel.readStrongBinder()));
                    return true;
                case 6:
                    cancelUniqueWork(parcel.readString(), IWorkManagerImplCallback.Stub.asInterface(parcel.readStrongBinder()));
                    return true;
                case 7:
                    cancelAllWork(IWorkManagerImplCallback.Stub.asInterface(parcel.readStrongBinder()));
                    return true;
                case 8:
                    queryWorkInfo(parcel.createByteArray(), IWorkManagerImplCallback.Stub.asInterface(parcel.readStrongBinder()));
                    return true;
                case 9:
                    setProgress(parcel.createByteArray(), IWorkManagerImplCallback.Stub.asInterface(parcel.readStrongBinder()));
                    return true;
                case 10:
                    setForegroundAsync(parcel.createByteArray(), IWorkManagerImplCallback.Stub.asInterface(parcel.readStrongBinder()));
                    return true;
                default:
                    return super.onTransact(i, parcel, parcel2, i2);
            }
        }

        private static class Proxy implements IWorkManagerImpl {
            private IBinder mRemote;

            Proxy(IBinder iBinder) {
                this.mRemote = iBinder;
            }

            @Override // android.os.IInterface
            public IBinder asBinder() {
                return this.mRemote;
            }
        }
    }
}
