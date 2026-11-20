package androidx.camera.core.impl;

import android.os.SystemClock;
import androidx.camera.core.impl.utils.executor.CameraXExecutors;
import androidx.concurrent.futures.CallbackToFutureAdapter;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.Observer;
import com.google.common.util.concurrent.ListenableFuture;
import com.scanflow.datacapture.barinternal.androidx.core.util.Preconditions;
import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.Executor;
import java.util.concurrent.atomic.AtomicBoolean;

/* JADX INFO: loaded from: classes.dex */
public final class LiveDataObservable implements Observable {
    final MutableLiveData mLiveData = new MutableLiveData();
    private final Map mObservers = new HashMap();

    public void postValue(Object obj) {
        this.mLiveData.postValue(Result.fromValue(obj));
    }

    @Override // androidx.camera.core.impl.Observable
    public ListenableFuture fetchData() {
        return CallbackToFutureAdapter.getFuture(new CallbackToFutureAdapter.Resolver() { // from class: androidx.camera.core.impl.LiveDataObservable$$ExternalSyntheticLambda2
            @Override // androidx.concurrent.futures.CallbackToFutureAdapter.Resolver
            public final Object attachCompleter(CallbackToFutureAdapter.Completer completer) {
                return LiveDataObservable.m29$r8$lambda$DTQl2TjsJw2q1DsAXZ5y6fSWXY(this.f$0, completer);
            }
        });
    }

    /* JADX INFO: renamed from: $r8$lambda$DTQl2TjsJw2q-1DsAXZ5y6fSWXY, reason: not valid java name */
    public static /* synthetic */ Object m29$r8$lambda$DTQl2TjsJw2q1DsAXZ5y6fSWXY(final LiveDataObservable liveDataObservable, final CallbackToFutureAdapter.Completer completer) {
        liveDataObservable.getClass();
        CameraXExecutors.mainThreadExecutor().execute(new Runnable() { // from class: androidx.camera.core.impl.LiveDataObservable$$ExternalSyntheticLambda3
            @Override // java.lang.Runnable
            public final void run() {
                LiveDataObservable.$r8$lambda$sc5wmr8WXbqD092EUWP6jtN6OSA(this.f$0, completer);
            }
        });
        return liveDataObservable + " [fetch@" + SystemClock.uptimeMillis() + "]";
    }

    /* JADX WARN: Multi-variable type inference failed */
    public static /* synthetic */ void $r8$lambda$sc5wmr8WXbqD092EUWP6jtN6OSA(LiveDataObservable liveDataObservable, CallbackToFutureAdapter.Completer completer) {
        Result result = (Result) liveDataObservable.mLiveData.getValue();
        if (result == null) {
            completer.setException(new IllegalStateException("Observable has not yet been initialized with a value."));
        } else if (result.completedSuccessfully()) {
            completer.set(result.getValue());
        } else {
            Preconditions.checkNotNull(result.getError());
            completer.setException(result.getError());
        }
    }

    @Override // androidx.camera.core.impl.Observable
    public void addObserver(Executor executor, Observable.Observer observer) {
        synchronized (this.mObservers) {
            try {
                final LiveDataObserverAdapter liveDataObserverAdapter = (LiveDataObserverAdapter) this.mObservers.get(observer);
                if (liveDataObserverAdapter != null) {
                    liveDataObserverAdapter.disable();
                }
                final LiveDataObserverAdapter liveDataObserverAdapter2 = new LiveDataObserverAdapter(executor, observer);
                this.mObservers.put(observer, liveDataObserverAdapter2);
                CameraXExecutors.mainThreadExecutor().execute(new Runnable() { // from class: androidx.camera.core.impl.LiveDataObservable$$ExternalSyntheticLambda1
                    @Override // java.lang.Runnable
                    public final void run() {
                        LiveDataObservable.$r8$lambda$wYXY5PQhuLafSvGd6glFwFsQmzA(this.f$0, liveDataObserverAdapter, liveDataObserverAdapter2);
                    }
                });
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public static /* synthetic */ void $r8$lambda$wYXY5PQhuLafSvGd6glFwFsQmzA(LiveDataObservable liveDataObservable, LiveDataObserverAdapter liveDataObserverAdapter, LiveDataObserverAdapter liveDataObserverAdapter2) {
        if (liveDataObserverAdapter != null) {
            liveDataObservable.mLiveData.removeObserver(liveDataObserverAdapter);
        }
        liveDataObservable.mLiveData.observeForever(liveDataObserverAdapter2);
    }

    @Override // androidx.camera.core.impl.Observable
    public void removeObserver(Observable.Observer observer) {
        synchronized (this.mObservers) {
            try {
                final LiveDataObserverAdapter liveDataObserverAdapter = (LiveDataObserverAdapter) this.mObservers.remove(observer);
                if (liveDataObserverAdapter != null) {
                    liveDataObserverAdapter.disable();
                    CameraXExecutors.mainThreadExecutor().execute(new Runnable() { // from class: androidx.camera.core.impl.LiveDataObservable$$ExternalSyntheticLambda0
                        @Override // java.lang.Runnable
                        public final void run() {
                            this.f$0.mLiveData.removeObserver(liveDataObserverAdapter);
                        }
                    });
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public static final class Result {
        private final Throwable mError;
        private final Object mValue;

        private Result(Object obj, Throwable th) {
            this.mValue = obj;
            this.mError = th;
        }

        static Result fromValue(Object obj) {
            return new Result(obj, null);
        }

        public boolean completedSuccessfully() {
            return this.mError == null;
        }

        public Object getValue() {
            if (!completedSuccessfully()) {
                throw new IllegalStateException("Result contains an error. Does not contain a value.");
            }
            return this.mValue;
        }

        public Throwable getError() {
            return this.mError;
        }

        public String toString() {
            String str;
            StringBuilder sb = new StringBuilder();
            sb.append("[Result: <");
            if (completedSuccessfully()) {
                str = "Value: " + this.mValue;
            } else {
                str = "Error: " + this.mError;
            }
            sb.append(str);
            sb.append(">]");
            return sb.toString();
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    static final class LiveDataObserverAdapter implements Observer {
        final AtomicBoolean mActive = new AtomicBoolean(true);
        final Executor mExecutor;
        final Observable.Observer mObserver;

        LiveDataObserverAdapter(Executor executor, Observable.Observer observer) {
            this.mExecutor = executor;
            this.mObserver = observer;
        }

        void disable() {
            this.mActive.set(false);
        }

        @Override // androidx.lifecycle.Observer
        public void onChanged(final Result result) {
            this.mExecutor.execute(new Runnable() { // from class: androidx.camera.core.impl.LiveDataObservable$LiveDataObserverAdapter$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    LiveDataObservable.LiveDataObserverAdapter.m30$r8$lambda$SW8l3Ry5_qeZWljPdU_ayE_pAA(this.f$0, result);
                }
            });
        }

        /* JADX INFO: renamed from: $r8$lambda$SW-8l3Ry5_qeZWljPdU_ayE_pAA, reason: not valid java name */
        public static /* synthetic */ void m30$r8$lambda$SW8l3Ry5_qeZWljPdU_ayE_pAA(LiveDataObserverAdapter liveDataObserverAdapter, Result result) {
            if (liveDataObserverAdapter.mActive.get()) {
                if (result.completedSuccessfully()) {
                    liveDataObserverAdapter.mObserver.onNewData(result.getValue());
                } else {
                    Preconditions.checkNotNull(result.getError());
                    liveDataObserverAdapter.mObserver.onError(result.getError());
                }
            }
        }
    }
}
