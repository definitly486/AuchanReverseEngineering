package androidx.room.util;

import androidx.room.DatabaseConfiguration;
import androidx.room.RoomDatabase;
import androidx.room.migration.Migration;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: MigrationUtil.kt */
/* JADX INFO: loaded from: classes.dex */
public final class MigrationUtil {
    public static final boolean isMigrationRequired(DatabaseConfiguration databaseConfiguration, int i, int i2) {
        Intrinsics.checkNotNullParameter(databaseConfiguration, "<this>");
        if (i > i2 && databaseConfiguration.allowDestructiveMigrationOnDowngrade) {
            return false;
        }
        Set migrationNotRequiredFrom$room_runtime_release = databaseConfiguration.getMigrationNotRequiredFrom$room_runtime_release();
        return databaseConfiguration.requireMigration && (migrationNotRequiredFrom$room_runtime_release == null || !migrationNotRequiredFrom$room_runtime_release.contains(Integer.valueOf(i)));
    }

    public static final boolean contains(RoomDatabase.MigrationContainer migrationContainer, int i, int i2) {
        Intrinsics.checkNotNullParameter(migrationContainer, "<this>");
        Map<Integer, Map<Integer, Migration>> migrations = migrationContainer.getMigrations();
        if (!migrations.containsKey(Integer.valueOf(i))) {
            return false;
        }
        Map<Integer, Migration> mapEmptyMap = migrations.get(Integer.valueOf(i));
        if (mapEmptyMap == null) {
            mapEmptyMap = MapsKt.emptyMap();
        }
        return mapEmptyMap.containsKey(Integer.valueOf(i2));
    }

    public static final List findMigrationPath(RoomDatabase.MigrationContainer migrationContainer, int i, int i2) {
        Intrinsics.checkNotNullParameter(migrationContainer, "<this>");
        if (i == i2) {
            return CollectionsKt.emptyList();
        }
        return findUpMigrationPath(migrationContainer, new ArrayList(), i2 > i, i, i2);
    }

    private static final List findUpMigrationPath(RoomDatabase.MigrationContainer migrationContainer, List list, boolean z, int i, int i2) {
        Pair sortedNodes$room_runtime_release;
        int iIntValue;
        boolean z2;
        while (true) {
            if (z) {
                if (i >= i2) {
                    return list;
                }
            } else if (i <= i2) {
                return list;
            }
            if (z) {
                sortedNodes$room_runtime_release = migrationContainer.getSortedDescendingNodes$room_runtime_release(i);
            } else {
                sortedNodes$room_runtime_release = migrationContainer.getSortedNodes$room_runtime_release(i);
            }
            if (sortedNodes$room_runtime_release == null) {
                return null;
            }
            Map map = (Map) sortedNodes$room_runtime_release.component1();
            Iterator it = ((Iterable) sortedNodes$room_runtime_release.component2()).iterator();
            while (true) {
                if (!it.hasNext()) {
                    iIntValue = i;
                    z2 = false;
                    break;
                }
                iIntValue = ((Number) it.next()).intValue();
                if (!z) {
                    if (i2 <= iIntValue && iIntValue < i) {
                        Object obj = map.get(Integer.valueOf(iIntValue));
                        Intrinsics.checkNotNull(obj);
                        list.add(obj);
                        z2 = true;
                        break;
                    }
                } else if (i + 1 <= iIntValue && iIntValue <= i2) {
                    Object obj2 = map.get(Integer.valueOf(iIntValue));
                    Intrinsics.checkNotNull(obj2);
                    list.add(obj2);
                    z2 = true;
                    break;
                }
            }
            if (!z2) {
                return null;
            }
            i = iIntValue;
        }
    }
}
