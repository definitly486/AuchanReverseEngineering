package androidx.work.impl.model;

import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: SystemIdInfoDao.kt */
/* JADX INFO: loaded from: classes.dex */
public interface SystemIdInfoDao {
    SystemIdInfo getSystemIdInfo(String str, int i);

    List<String> getWorkSpecIds();

    void insertSystemIdInfo(SystemIdInfo systemIdInfo);

    void removeSystemIdInfo(String str);

    void removeSystemIdInfo(String str, int i);

    /* JADX INFO: compiled from: SystemIdInfoDao.kt */
    public static final class DefaultImpls {
        @Deprecated
        public static SystemIdInfo getSystemIdInfo(SystemIdInfoDao systemIdInfoDao, WorkGenerationalId id) {
            Intrinsics.checkNotNullParameter(id, "id");
            return SystemIdInfoDao.super.getSystemIdInfo(id);
        }

        @Deprecated
        public static void removeSystemIdInfo(SystemIdInfoDao systemIdInfoDao, WorkGenerationalId id) {
            Intrinsics.checkNotNullParameter(id, "id");
            SystemIdInfoDao.super.removeSystemIdInfo(id);
        }
    }

    default SystemIdInfo getSystemIdInfo(WorkGenerationalId id) {
        Intrinsics.checkNotNullParameter(id, "id");
        return getSystemIdInfo(id.getWorkSpecId(), id.getGeneration());
    }

    default void removeSystemIdInfo(WorkGenerationalId id) {
        Intrinsics.checkNotNullParameter(id, "id");
        removeSystemIdInfo(id.getWorkSpecId(), id.getGeneration());
    }
}
