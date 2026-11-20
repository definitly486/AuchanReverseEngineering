.class public final Landroidx/room/paging/CursorSQLiteStatement;
.super Ljava/lang/Object;
.source "CursorSQLiteStatement.android.kt"

# interfaces
.implements Landroidx/sqlite/SQLiteStatement;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Landroidx/room/paging/CursorSQLiteStatement$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Landroidx/room/paging/CursorSQLiteStatement$Companion;


# instance fields
.field private final cursor:Landroid/database/Cursor;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Landroidx/room/paging/CursorSQLiteStatement$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Landroidx/room/paging/CursorSQLiteStatement$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Landroidx/room/paging/CursorSQLiteStatement;->Companion:Landroidx/room/paging/CursorSQLiteStatement$Companion;

    return-void
.end method

.method public constructor <init>(Landroid/database/Cursor;)V
    .locals 1

    const-string v0, "cursor"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 35
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    return-void
.end method


# virtual methods
.method public bindBlob(I[B)Ljava/lang/Void;
    .locals 0

    const-string p1, "value"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance p1, Ljava/lang/IllegalStateException;

    .line 63
    const-string p2, "Only get*() calls are allowed on a Cursor backed SQLiteStatement"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic bindBlob(I[B)V
    .locals 0

    .line 34
    invoke-virtual {p0, p1, p2}, Landroidx/room/paging/CursorSQLiteStatement;->bindBlob(I[B)Ljava/lang/Void;

    return-void
.end method

.method public bindDouble(ID)Ljava/lang/Void;
    .locals 0

    new-instance p1, Ljava/lang/IllegalStateException;

    .line 66
    const-string p2, "Only get*() calls are allowed on a Cursor backed SQLiteStatement"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic bindDouble(ID)V
    .locals 0

    .line 34
    invoke-virtual {p0, p1, p2, p3}, Landroidx/room/paging/CursorSQLiteStatement;->bindDouble(ID)Ljava/lang/Void;

    return-void
.end method

.method public bindLong(IJ)Ljava/lang/Void;
    .locals 0

    new-instance p1, Ljava/lang/IllegalStateException;

    .line 69
    const-string p2, "Only get*() calls are allowed on a Cursor backed SQLiteStatement"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic bindLong(IJ)V
    .locals 0

    .line 34
    invoke-virtual {p0, p1, p2, p3}, Landroidx/room/paging/CursorSQLiteStatement;->bindLong(IJ)Ljava/lang/Void;

    return-void
.end method

.method public bindNull(I)Ljava/lang/Void;
    .locals 1

    new-instance p1, Ljava/lang/IllegalStateException;

    .line 75
    const-string v0, "Only get*() calls are allowed on a Cursor backed SQLiteStatement"

    invoke-direct {p1, v0}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic bindNull(I)V
    .locals 0

    .line 34
    invoke-virtual {p0, p1}, Landroidx/room/paging/CursorSQLiteStatement;->bindNull(I)Ljava/lang/Void;

    return-void
.end method

.method public bindText(ILjava/lang/String;)Ljava/lang/Void;
    .locals 0

    const-string p1, "value"

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance p1, Ljava/lang/IllegalStateException;

    .line 72
    const-string p2, "Only get*() calls are allowed on a Cursor backed SQLiteStatement"

    invoke-direct {p1, p2}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw p1
.end method

.method public bridge synthetic bindText(ILjava/lang/String;)V
    .locals 0

    .line 34
    invoke-virtual {p0, p1, p2}, Landroidx/room/paging/CursorSQLiteStatement;->bindText(ILjava/lang/String;)Ljava/lang/Void;

    return-void
.end method

.method public clearBindings()Ljava/lang/Void;
    .locals 2

    new-instance v0, Ljava/lang/IllegalStateException;

    .line 78
    const-string v1, "Only get*() calls are allowed on a Cursor backed SQLiteStatement"

    invoke-direct {v0, v1}, Ljava/lang/IllegalStateException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public bridge synthetic clearBindings()V
    .locals 0

    .line 34
    invoke-virtual {p0}, Landroidx/room/paging/CursorSQLiteStatement;->clearBindings()Ljava/lang/Void;

    return-void
.end method

.method public close()V
    .locals 1

    .line 59
    iget-object v0, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    invoke-interface {v0}, Landroid/database/Cursor;->close()V

    return-void
.end method

.method public getBlob(I)[B
    .locals 1

    .line 36
    iget-object v0, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    invoke-interface {v0, p1}, Landroid/database/Cursor;->getBlob(I)[B

    move-result-object p1

    const-string v0, "getBlob(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p1
.end method

.method public getColumnCount()I
    .locals 1

    .line 46
    iget-object v0, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    invoke-interface {v0}, Landroid/database/Cursor;->getColumnCount()I

    move-result v0

    return v0
.end method

.method public getColumnName(I)Ljava/lang/String;
    .locals 1

    .line 48
    iget-object v0, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    invoke-interface {v0, p1}, Landroid/database/Cursor;->getColumnName(I)Ljava/lang/String;

    move-result-object p1

    const-string v0, "getColumnName(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p1
.end method

.method public getColumnType(I)I
    .locals 2

    .line 50
    sget-object v0, Landroidx/room/paging/CursorSQLiteStatement;->Companion:Landroidx/room/paging/CursorSQLiteStatement$Companion;

    iget-object v1, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    invoke-static {v0, v1, p1}, Landroidx/room/paging/CursorSQLiteStatement$Companion;->access$getDataType(Landroidx/room/paging/CursorSQLiteStatement$Companion;Landroid/database/Cursor;I)I

    move-result p1

    return p1
.end method

.method public getDouble(I)D
    .locals 2

    .line 38
    iget-object v0, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    invoke-interface {v0, p1}, Landroid/database/Cursor;->getDouble(I)D

    move-result-wide v0

    return-wide v0
.end method

.method public getLong(I)J
    .locals 2

    .line 40
    iget-object v0, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    invoke-interface {v0, p1}, Landroid/database/Cursor;->getLong(I)J

    move-result-wide v0

    return-wide v0
.end method

.method public getText(I)Ljava/lang/String;
    .locals 1

    .line 42
    iget-object v0, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    invoke-interface {v0, p1}, Landroid/database/Cursor;->getString(I)Ljava/lang/String;

    move-result-object p1

    const-string v0, "getString(...)"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullExpressionValue(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p1
.end method

.method public isNull(I)Z
    .locals 1

    .line 44
    iget-object v0, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    invoke-interface {v0, p1}, Landroid/database/Cursor;->isNull(I)Z

    move-result p1

    return p1
.end method

.method public reset()V
    .locals 2

    .line 55
    iget-object v0, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    const/4 v1, -0x1

    invoke-interface {v0, v1}, Landroid/database/Cursor;->moveToPosition(I)Z

    return-void
.end method

.method public step()Z
    .locals 1

    .line 52
    iget-object v0, p0, Landroidx/room/paging/CursorSQLiteStatement;->cursor:Landroid/database/Cursor;

    invoke-interface {v0}, Landroid/database/Cursor;->moveToNext()Z

    move-result v0

    return v0
.end method
