package androidx.room.util;

import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ViewInfo.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ViewInfoKt {
    public static final boolean equalsCommon(ViewInfo viewInfo, Object obj) {
        boolean zAreEqual;
        Intrinsics.checkNotNullParameter(viewInfo, "<this>");
        if (viewInfo == obj) {
            return true;
        }
        if (!(obj instanceof ViewInfo)) {
            return false;
        }
        ViewInfo viewInfo2 = (ViewInfo) obj;
        if (Intrinsics.areEqual(viewInfo.name, viewInfo2.name)) {
            String str = viewInfo.sql;
            if (str != null) {
                zAreEqual = Intrinsics.areEqual(str, viewInfo2.sql);
            } else {
                zAreEqual = viewInfo2.sql == null;
            }
            if (zAreEqual) {
                return true;
            }
        }
        return false;
    }

    public static final int hashCodeCommon(ViewInfo viewInfo) {
        Intrinsics.checkNotNullParameter(viewInfo, "<this>");
        int iHashCode = viewInfo.name.hashCode() * 31;
        String str = viewInfo.sql;
        return iHashCode + (str != null ? str.hashCode() : 0);
    }

    public static final String toStringCommon(ViewInfo viewInfo) {
        Intrinsics.checkNotNullParameter(viewInfo, "<this>");
        return StringsKt.trimMargin$default("\n            |ViewInfo {\n            |   name = '" + viewInfo.name + "',\n            |   sql = '" + viewInfo.sql + "'\n            |}\n        ", null, 1, null);
    }
}
