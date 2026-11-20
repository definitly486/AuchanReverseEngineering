package androidx.room;

import android.database.SQLException;
import androidx.sqlite.SQLiteConnection;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.util.Collection;
import java.util.List;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: EntityUpsertAdapter.kt */
/* JADX INFO: loaded from: classes.dex */
public final class EntityUpsertAdapter<T> {
    public static final Companion Companion = new Companion(null);
    private final EntityInsertAdapter entityInsertAdapter;
    private final EntityDeleteOrUpdateAdapter updateAdapter;

    public EntityUpsertAdapter(EntityInsertAdapter<T> entityInsertAdapter, EntityDeleteOrUpdateAdapter<T> updateAdapter) {
        Intrinsics.checkNotNullParameter(entityInsertAdapter, "entityInsertAdapter");
        Intrinsics.checkNotNullParameter(updateAdapter, "updateAdapter");
        this.entityInsertAdapter = entityInsertAdapter;
        this.updateAdapter = updateAdapter;
    }

    public final void upsert(SQLiteConnection connection, T t) throws Exception {
        Intrinsics.checkNotNullParameter(connection, "connection");
        try {
            this.entityInsertAdapter.insert(connection, t);
        } catch (SQLException e) {
            checkUniquenessException(e);
            this.updateAdapter.handle(connection, t);
        }
    }

    public final long upsertAndReturnId(SQLiteConnection connection, T t) throws Exception {
        Intrinsics.checkNotNullParameter(connection, "connection");
        try {
            return this.entityInsertAdapter.insertAndReturnId(connection, t);
        } catch (SQLException e) {
            checkUniquenessException(e);
            this.updateAdapter.handle(connection, t);
            return -1L;
        }
    }

    public final long[] upsertAndReturnIdsArray(SQLiteConnection connection, T[] tArr) throws Exception {
        long jInsertAndReturnId;
        Intrinsics.checkNotNullParameter(connection, "connection");
        if (tArr == null) {
            return new long[0];
        }
        int length = tArr.length;
        long[] jArr = new long[length];
        for (int i = 0; i < length; i++) {
            try {
                jInsertAndReturnId = this.entityInsertAdapter.insertAndReturnId(connection, tArr[i]);
            } catch (SQLException e) {
                checkUniquenessException(e);
                this.updateAdapter.handle(connection, tArr[i]);
                jInsertAndReturnId = -1;
            }
            jArr[i] = jInsertAndReturnId;
        }
        return jArr;
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final long[] upsertAndReturnIdsArray(SQLiteConnection connection, Collection<? extends T> collection) throws Exception {
        long jInsertAndReturnId;
        Intrinsics.checkNotNullParameter(connection, "connection");
        if (collection == null) {
            return new long[0];
        }
        int size = collection.size();
        long[] jArr = new long[size];
        for (int i = 0; i < size; i++) {
            try {
                jInsertAndReturnId = this.entityInsertAdapter.insertAndReturnId(connection, CollectionsKt.elementAt(collection, i));
            } catch (SQLException e) {
                checkUniquenessException(e);
                this.updateAdapter.handle(connection, CollectionsKt.elementAt(collection, i));
                jInsertAndReturnId = -1;
            }
            jArr[i] = jInsertAndReturnId;
        }
        return jArr;
    }

    public final List<Long> upsertAndReturnIdsList(SQLiteConnection connection, T[] tArr) throws Exception {
        Intrinsics.checkNotNullParameter(connection, "connection");
        if (tArr == null) {
            return CollectionsKt.emptyList();
        }
        List listCreateListBuilder = CollectionsKt.createListBuilder();
        for (T t : tArr) {
            try {
                listCreateListBuilder.add(Long.valueOf(this.entityInsertAdapter.insertAndReturnId(connection, t)));
            } catch (SQLException e) {
                checkUniquenessException(e);
                this.updateAdapter.handle(connection, t);
                listCreateListBuilder.add(-1L);
            }
        }
        return CollectionsKt.build(listCreateListBuilder);
    }

    public final List<Long> upsertAndReturnIdsList(SQLiteConnection connection, Collection<? extends T> collection) throws Exception {
        Intrinsics.checkNotNullParameter(connection, "connection");
        if (collection == null) {
            return CollectionsKt.emptyList();
        }
        List listCreateListBuilder = CollectionsKt.createListBuilder();
        for (T t : collection) {
            try {
                listCreateListBuilder.add(Long.valueOf(this.entityInsertAdapter.insertAndReturnId(connection, t)));
            } catch (SQLException e) {
                checkUniquenessException(e);
                this.updateAdapter.handle(connection, t);
                listCreateListBuilder.add(-1L);
            }
        }
        return CollectionsKt.build(listCreateListBuilder);
    }

    public final Long[] upsertAndReturnIdsArrayBox(SQLiteConnection connection, T[] tArr) throws Exception {
        long jInsertAndReturnId;
        Intrinsics.checkNotNullParameter(connection, "connection");
        if (tArr == null) {
            return new Long[0];
        }
        int length = tArr.length;
        Long[] lArr = new Long[length];
        for (int i = 0; i < length; i++) {
            try {
                jInsertAndReturnId = this.entityInsertAdapter.insertAndReturnId(connection, tArr[i]);
            } catch (SQLException e) {
                checkUniquenessException(e);
                this.updateAdapter.handle(connection, tArr[i]);
                jInsertAndReturnId = -1;
            }
            lArr[i] = Long.valueOf(jInsertAndReturnId);
        }
        return lArr;
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final Long[] upsertAndReturnIdsArrayBox(SQLiteConnection connection, Collection<? extends T> collection) throws Exception {
        long jInsertAndReturnId;
        Intrinsics.checkNotNullParameter(connection, "connection");
        if (collection == null) {
            return new Long[0];
        }
        int size = collection.size();
        Long[] lArr = new Long[size];
        for (int i = 0; i < size; i++) {
            try {
                jInsertAndReturnId = this.entityInsertAdapter.insertAndReturnId(connection, CollectionsKt.elementAt(collection, i));
            } catch (SQLException e) {
                checkUniquenessException(e);
                this.updateAdapter.handle(connection, CollectionsKt.elementAt(collection, i));
                jInsertAndReturnId = -1;
            }
            lArr[i] = Long.valueOf(jInsertAndReturnId);
        }
        return lArr;
    }

    private final void checkUniquenessException(SQLException sQLException) {
        String message = sQLException.getMessage();
        if (message == null) {
            throw sQLException;
        }
        if (!StringsKt.contains((CharSequence) message, (CharSequence) "unique", true) && !StringsKt.contains$default((CharSequence) message, (CharSequence) "2067", false, 2, (Object) null) && !StringsKt.contains$default((CharSequence) message, (CharSequence) "1555", false, 2, (Object) null)) {
            throw sQLException;
        }
    }

    /* JADX INFO: compiled from: EntityUpsertAdapter.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }
    }

    public final void upsert(SQLiteConnection connection, T[] tArr) throws Exception {
        Intrinsics.checkNotNullParameter(connection, "connection");
        if (tArr == null) {
            return;
        }
        for (T t : tArr) {
            try {
                this.entityInsertAdapter.insert(connection, t);
            } catch (SQLException e) {
                checkUniquenessException(e);
                this.updateAdapter.handle(connection, t);
            }
        }
    }

    public final void upsert(SQLiteConnection connection, Iterable<? extends T> iterable) throws Exception {
        Intrinsics.checkNotNullParameter(connection, "connection");
        if (iterable == null) {
            return;
        }
        for (T t : iterable) {
            try {
                this.entityInsertAdapter.insert(connection, t);
            } catch (SQLException e) {
                checkUniquenessException(e);
                this.updateAdapter.handle(connection, t);
            }
        }
    }
}
