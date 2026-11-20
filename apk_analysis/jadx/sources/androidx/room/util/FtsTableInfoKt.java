package androidx.room.util;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: FtsTableInfo.kt */
/* JADX INFO: loaded from: classes.dex */
public final class FtsTableInfoKt {
    public static final boolean equalsCommon(FtsTableInfo ftsTableInfo, Object obj) {
        Intrinsics.checkNotNullParameter(ftsTableInfo, "<this>");
        if (ftsTableInfo == obj) {
            return true;
        }
        if (!(obj instanceof FtsTableInfo)) {
            return false;
        }
        FtsTableInfo ftsTableInfo2 = (FtsTableInfo) obj;
        if (Intrinsics.areEqual(ftsTableInfo.name, ftsTableInfo2.name) && Intrinsics.areEqual(ftsTableInfo.columns, ftsTableInfo2.columns)) {
            return Intrinsics.areEqual(ftsTableInfo.options, ftsTableInfo2.options);
        }
        return false;
    }

    public static final int hashCodeCommon(FtsTableInfo ftsTableInfo) {
        Intrinsics.checkNotNullParameter(ftsTableInfo, "<this>");
        return (((ftsTableInfo.name.hashCode() * 31) + ftsTableInfo.columns.hashCode()) * 31) + ftsTableInfo.options.hashCode();
    }

    public static final String toStringCommon(FtsTableInfo ftsTableInfo) {
        Intrinsics.checkNotNullParameter(ftsTableInfo, "<this>");
        return StringsKt.trimMargin$default("\n            |FtsTableInfo {\n            |   name = '" + ftsTableInfo.name + "',\n            |   columns = {" + TableInfoKt.formatString(CollectionsKt.sorted(ftsTableInfo.columns)) + "\n            |   options = {" + TableInfoKt.formatString(CollectionsKt.sorted(ftsTableInfo.options)) + "\n            |}\n        ", null, 1, null);
    }
}
