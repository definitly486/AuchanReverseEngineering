.class final Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteOpenHelper$DBRefHolder;
.super Ljava/lang/Object;
.source "FrameworkSQLiteOpenHelper.android.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteOpenHelper;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "DBRefHolder"
.end annotation


# instance fields
.field private db:Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteDatabase;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteDatabase;)V
    .locals 0

    .line 335
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteOpenHelper$DBRefHolder;->db:Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteDatabase;

    return-void
.end method


# virtual methods
.method public final getDb()Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteDatabase;
    .locals 1

    .line 335
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteOpenHelper$DBRefHolder;->db:Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteDatabase;

    return-object v0
.end method

.method public final setDb(Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteDatabase;)V
    .locals 0

    .line 335
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteOpenHelper$DBRefHolder;->db:Lcom/scanflow/datacapture/barinternal/androidx/sqlite/db/framework/FrameworkSQLiteDatabase;

    return-void
.end method
