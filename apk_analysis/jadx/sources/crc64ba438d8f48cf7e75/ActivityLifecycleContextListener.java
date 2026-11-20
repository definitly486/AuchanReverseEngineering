package crc64ba438d8f48cf7e75;

import android.app.Activity;
import android.app.Application;
import android.os.Bundle;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ActivityLifecycleContextListener implements IGCUserPeer, Application.ActivityLifecycleCallbacks {
    private ArrayList refList;

    private native void n_onActivityCreated(Activity activity, Bundle bundle);

    private native void n_onActivityDestroyed(Activity activity);

    private native void n_onActivityPaused(Activity activity);

    private native void n_onActivityPostCreated(Activity activity, Bundle bundle);

    private native void n_onActivityPostDestroyed(Activity activity);

    private native void n_onActivityPostPaused(Activity activity);

    private native void n_onActivityPostResumed(Activity activity);

    private native void n_onActivityPostSaveInstanceState(Activity activity, Bundle bundle);

    private native void n_onActivityPostStarted(Activity activity);

    private native void n_onActivityPostStopped(Activity activity);

    private native void n_onActivityPreCreated(Activity activity, Bundle bundle);

    private native void n_onActivityPreDestroyed(Activity activity);

    private native void n_onActivityPrePaused(Activity activity);

    private native void n_onActivityPreResumed(Activity activity);

    private native void n_onActivityPreSaveInstanceState(Activity activity, Bundle bundle);

    private native void n_onActivityPreStarted(Activity activity);

    private native void n_onActivityPreStopped(Activity activity);

    private native void n_onActivityResumed(Activity activity);

    private native void n_onActivitySaveInstanceState(Activity activity, Bundle bundle);

    private native void n_onActivityStarted(Activity activity);

    private native void n_onActivityStopped(Activity activity);

    public ActivityLifecycleContextListener() {
        if (getClass() == ActivityLifecycleContextListener.class) {
            TypeManager.Activate("Microsoft.Maui.ApplicationModel.ActivityLifecycleContextListener, Microsoft.Maui.Essentials", "", this, new Object[0]);
        }
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityCreated(Activity activity, Bundle bundle) {
        n_onActivityCreated(activity, bundle);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityDestroyed(Activity activity) {
        n_onActivityDestroyed(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPaused(Activity activity) {
        n_onActivityPaused(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityResumed(Activity activity) {
        n_onActivityResumed(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivitySaveInstanceState(Activity activity, Bundle bundle) {
        n_onActivitySaveInstanceState(activity, bundle);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityStarted(Activity activity) {
        n_onActivityStarted(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityStopped(Activity activity) {
        n_onActivityStopped(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPostCreated(Activity activity, Bundle bundle) {
        n_onActivityPostCreated(activity, bundle);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPostDestroyed(Activity activity) {
        n_onActivityPostDestroyed(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPostPaused(Activity activity) {
        n_onActivityPostPaused(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPostResumed(Activity activity) {
        n_onActivityPostResumed(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPostSaveInstanceState(Activity activity, Bundle bundle) {
        n_onActivityPostSaveInstanceState(activity, bundle);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPostStarted(Activity activity) {
        n_onActivityPostStarted(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPostStopped(Activity activity) {
        n_onActivityPostStopped(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPreCreated(Activity activity, Bundle bundle) {
        n_onActivityPreCreated(activity, bundle);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPreDestroyed(Activity activity) {
        n_onActivityPreDestroyed(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPrePaused(Activity activity) {
        n_onActivityPrePaused(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPreResumed(Activity activity) {
        n_onActivityPreResumed(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPreSaveInstanceState(Activity activity, Bundle bundle) {
        n_onActivityPreSaveInstanceState(activity, bundle);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPreStarted(Activity activity) {
        n_onActivityPreStarted(activity);
    }

    @Override // android.app.Application.ActivityLifecycleCallbacks
    public void onActivityPreStopped(Activity activity) {
        n_onActivityPreStopped(activity);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
