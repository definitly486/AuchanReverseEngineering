package com.scanflow.datacapture.utils;

import android.app.Activity;
import android.content.Context;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.Fragment;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class PermissionUtils {
    public static final PermissionUtils INSTANCE = new PermissionUtils();

    private PermissionUtils() {
    }

    public final boolean checkPermission(Context context, String permission) {
        Intrinsics.checkNotNullParameter(context, "context");
        Intrinsics.checkNotNullParameter(permission, "permission");
        return ContextCompat.checkSelfPermission(context, permission) == 0;
    }

    public final void requestPermission(Activity activity, String permission, int i) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(permission, "permission");
        requestPermissions(activity, new String[]{permission}, i);
    }

    public final void requestPermissions(Activity activity, String[] permissions, int i) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(permissions, "permissions");
        ActivityCompat.requestPermissions(activity, permissions, i);
    }

    public final boolean requestPermissionsResult(String requestPermission, String[] permissions, int[] grantResults) {
        Intrinsics.checkNotNullParameter(requestPermission, "requestPermission");
        Intrinsics.checkNotNullParameter(permissions, "permissions");
        Intrinsics.checkNotNullParameter(grantResults, "grantResults");
        int length = permissions.length;
        for (int i = 0; i < length; i++) {
            if (Intrinsics.areEqual(requestPermission, permissions[i]) && grantResults[i] == 0) {
                return true;
            }
        }
        return false;
    }

    public final void requestPermission(Fragment fragment, String permission, int i) {
        Intrinsics.checkNotNullParameter(fragment, "fragment");
        Intrinsics.checkNotNullParameter(permission, "permission");
        requestPermissions(fragment, new String[]{permission}, i);
    }

    public final void requestPermissions(Fragment fragment, String[] permissions, int i) {
        Intrinsics.checkNotNullParameter(fragment, "fragment");
        Intrinsics.checkNotNullParameter(permissions, "permissions");
        fragment.requestPermissions(permissions, i);
    }

    public final boolean requestPermissionsResult(String[] requestPermissions, String[] permissions, int[] grantResults) {
        Intrinsics.checkNotNullParameter(requestPermissions, "requestPermissions");
        Intrinsics.checkNotNullParameter(permissions, "permissions");
        Intrinsics.checkNotNullParameter(grantResults, "grantResults");
        int length = permissions.length;
        for (int i = 0; i < length; i++) {
            for (String str : requestPermissions) {
                if (Intrinsics.areEqual(str, permissions[i]) && grantResults[i] != 0) {
                    return false;
                }
            }
        }
        return true;
    }
}
