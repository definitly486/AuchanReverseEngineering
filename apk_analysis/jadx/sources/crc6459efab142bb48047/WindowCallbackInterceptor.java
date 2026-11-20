package crc6459efab142bb48047;

import android.view.ActionMode;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.SearchEvent;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.view.accessibility.AccessibilityEvent;
import java.util.ArrayList;
import java.util.List;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class WindowCallbackInterceptor implements IGCUserPeer, Window.Callback {
    private ArrayList refList;

    private native boolean n_dispatchGenericMotionEvent(MotionEvent motionEvent);

    private native boolean n_dispatchKeyEvent(KeyEvent keyEvent);

    private native boolean n_dispatchKeyShortcutEvent(KeyEvent keyEvent);

    private native boolean n_dispatchPopulateAccessibilityEvent(AccessibilityEvent accessibilityEvent);

    private native boolean n_dispatchTouchEvent(MotionEvent motionEvent);

    private native boolean n_dispatchTrackballEvent(MotionEvent motionEvent);

    private native void n_onActionModeFinished(ActionMode actionMode);

    private native void n_onActionModeStarted(ActionMode actionMode);

    private native void n_onAttachedToWindow();

    private native void n_onContentChanged();

    private native boolean n_onCreatePanelMenu(int i, Menu menu);

    private native View n_onCreatePanelView(int i);

    private native void n_onDetachedFromWindow();

    private native boolean n_onMenuItemSelected(int i, MenuItem menuItem);

    private native boolean n_onMenuOpened(int i, Menu menu);

    private native void n_onPanelClosed(int i, Menu menu);

    private native void n_onPointerCaptureChanged(boolean z);

    private native boolean n_onPreparePanel(int i, View view, Menu menu);

    private native void n_onProvideKeyboardShortcuts(List list, Menu menu, int i);

    private native boolean n_onSearchRequested();

    private native boolean n_onSearchRequested(SearchEvent searchEvent);

    private native void n_onWindowAttributesChanged(WindowManager.LayoutParams layoutParams);

    private native void n_onWindowFocusChanged(boolean z);

    private native ActionMode n_onWindowStartingActionMode(ActionMode.Callback callback);

    private native ActionMode n_onWindowStartingActionMode(ActionMode.Callback callback, int i);

    public WindowCallbackInterceptor() {
        if (getClass() == WindowCallbackInterceptor.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.WindowCallbackInterceptor, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public WindowCallbackInterceptor(Window window) {
        if (getClass() == WindowCallbackInterceptor.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.WindowCallbackInterceptor, Auchan.Android.Net", "Android.Views.Window, Mono.Android", this, new Object[]{window});
        }
    }

    @Override // android.view.Window.Callback
    public boolean dispatchGenericMotionEvent(MotionEvent motionEvent) {
        return n_dispatchGenericMotionEvent(motionEvent);
    }

    @Override // android.view.Window.Callback
    public boolean dispatchKeyEvent(KeyEvent keyEvent) {
        return n_dispatchKeyEvent(keyEvent);
    }

    @Override // android.view.Window.Callback
    public boolean dispatchKeyShortcutEvent(KeyEvent keyEvent) {
        return n_dispatchKeyShortcutEvent(keyEvent);
    }

    @Override // android.view.Window.Callback
    public boolean dispatchPopulateAccessibilityEvent(AccessibilityEvent accessibilityEvent) {
        return n_dispatchPopulateAccessibilityEvent(accessibilityEvent);
    }

    @Override // android.view.Window.Callback
    public boolean dispatchTouchEvent(MotionEvent motionEvent) {
        return n_dispatchTouchEvent(motionEvent);
    }

    @Override // android.view.Window.Callback
    public boolean dispatchTrackballEvent(MotionEvent motionEvent) {
        return n_dispatchTrackballEvent(motionEvent);
    }

    @Override // android.view.Window.Callback
    public void onActionModeFinished(ActionMode actionMode) {
        n_onActionModeFinished(actionMode);
    }

    @Override // android.view.Window.Callback
    public void onActionModeStarted(ActionMode actionMode) {
        n_onActionModeStarted(actionMode);
    }

    @Override // android.view.Window.Callback
    public void onAttachedToWindow() {
        n_onAttachedToWindow();
    }

    @Override // android.view.Window.Callback
    public void onContentChanged() {
        n_onContentChanged();
    }

    @Override // android.view.Window.Callback
    public boolean onCreatePanelMenu(int i, Menu menu) {
        return n_onCreatePanelMenu(i, menu);
    }

    @Override // android.view.Window.Callback
    public View onCreatePanelView(int i) {
        return n_onCreatePanelView(i);
    }

    @Override // android.view.Window.Callback
    public void onDetachedFromWindow() {
        n_onDetachedFromWindow();
    }

    @Override // android.view.Window.Callback
    public boolean onMenuItemSelected(int i, MenuItem menuItem) {
        return n_onMenuItemSelected(i, menuItem);
    }

    @Override // android.view.Window.Callback
    public boolean onMenuOpened(int i, Menu menu) {
        return n_onMenuOpened(i, menu);
    }

    @Override // android.view.Window.Callback
    public void onPanelClosed(int i, Menu menu) {
        n_onPanelClosed(i, menu);
    }

    @Override // android.view.Window.Callback
    public boolean onPreparePanel(int i, View view, Menu menu) {
        return n_onPreparePanel(i, view, menu);
    }

    @Override // android.view.Window.Callback
    public boolean onSearchRequested() {
        return n_onSearchRequested();
    }

    @Override // android.view.Window.Callback
    public boolean onSearchRequested(SearchEvent searchEvent) {
        return n_onSearchRequested(searchEvent);
    }

    @Override // android.view.Window.Callback
    public void onWindowAttributesChanged(WindowManager.LayoutParams layoutParams) {
        n_onWindowAttributesChanged(layoutParams);
    }

    @Override // android.view.Window.Callback
    public void onWindowFocusChanged(boolean z) {
        n_onWindowFocusChanged(z);
    }

    @Override // android.view.Window.Callback
    public ActionMode onWindowStartingActionMode(ActionMode.Callback callback, int i) {
        return n_onWindowStartingActionMode(callback, i);
    }

    @Override // android.view.Window.Callback
    public ActionMode onWindowStartingActionMode(ActionMode.Callback callback) {
        return n_onWindowStartingActionMode(callback);
    }

    @Override // android.view.Window.Callback
    public void onPointerCaptureChanged(boolean z) {
        n_onPointerCaptureChanged(z);
    }

    @Override // android.view.Window.Callback
    public void onProvideKeyboardShortcuts(List list, Menu menu, int i) {
        n_onProvideKeyboardShortcuts(list, menu, i);
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
