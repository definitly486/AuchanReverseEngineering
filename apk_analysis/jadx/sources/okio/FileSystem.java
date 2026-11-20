package okio;

import com.scanflow.datacapture.barinternal.kotlin.sequences.Sequence;
import com.scanflow.datacapture.barinternal.okio.internal.ResourceFileSystem;
import java.util.List;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: FileSystem.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class FileSystem {
    public static final Companion Companion = new Companion(null);
    public static final FileSystem RESOURCES;
    public static final FileSystem SYSTEM;
    public static final Path SYSTEM_TEMPORARY_DIRECTORY;

    public static final FileSystem get(java.nio.file.FileSystem fileSystem) {
        return Companion.get(fileSystem);
    }

    public abstract Sink appendingSink(Path path, boolean z);

    public abstract void atomicMove(Path path, Path path2);

    public abstract Path canonicalize(Path path);

    public abstract void createDirectory(Path path, boolean z);

    public abstract void createSymlink(Path path, Path path2);

    public abstract void delete(Path path, boolean z);

    public abstract List<Path> list(Path path);

    public abstract List<Path> listOrNull(Path path);

    public abstract FileMetadata metadataOrNull(Path path);

    public abstract FileHandle openReadOnly(Path path);

    public abstract FileHandle openReadWrite(Path path, boolean z, boolean z2);

    public abstract Sink sink(Path path, boolean z);

    public abstract Source source(Path path);

    public final FileMetadata metadata(Path path) {
        Intrinsics.checkNotNullParameter(path, "path");
        return com.scanflow.datacapture.barinternal.okio.internal.FileSystem.commonMetadata(this, path);
    }

    public final boolean exists(Path path) {
        Intrinsics.checkNotNullParameter(path, "path");
        return com.scanflow.datacapture.barinternal.okio.internal.FileSystem.commonExists(this, path);
    }

    public Sequence listRecursively(Path dir, boolean z) {
        Intrinsics.checkNotNullParameter(dir, "dir");
        return com.scanflow.datacapture.barinternal.okio.internal.FileSystem.commonListRecursively(this, dir, z);
    }

    public final Sequence listRecursively(Path dir) {
        Intrinsics.checkNotNullParameter(dir, "dir");
        return listRecursively(dir, false);
    }

    public final FileHandle openReadWrite(Path file) {
        Intrinsics.checkNotNullParameter(file, "file");
        return openReadWrite(file, false, false);
    }

    public final Sink sink(Path file) {
        Intrinsics.checkNotNullParameter(file, "file");
        return sink(file, false);
    }

    public final Sink appendingSink(Path file) {
        Intrinsics.checkNotNullParameter(file, "file");
        return appendingSink(file, false);
    }

    public final void createDirectory(Path dir) {
        Intrinsics.checkNotNullParameter(dir, "dir");
        createDirectory(dir, false);
    }

    public final void createDirectories(Path dir, boolean z) {
        Intrinsics.checkNotNullParameter(dir, "dir");
        com.scanflow.datacapture.barinternal.okio.internal.FileSystem.commonCreateDirectories(this, dir, z);
    }

    public final void createDirectories(Path dir) {
        Intrinsics.checkNotNullParameter(dir, "dir");
        createDirectories(dir, false);
    }

    public void copy(Path source, Path target) {
        Intrinsics.checkNotNullParameter(source, "source");
        Intrinsics.checkNotNullParameter(target, "target");
        com.scanflow.datacapture.barinternal.okio.internal.FileSystem.commonCopy(this, source, target);
    }

    public final void delete(Path path) {
        Intrinsics.checkNotNullParameter(path, "path");
        delete(path, false);
    }

    public void deleteRecursively(Path fileOrDirectory, boolean z) {
        Intrinsics.checkNotNullParameter(fileOrDirectory, "fileOrDirectory");
        com.scanflow.datacapture.barinternal.okio.internal.FileSystem.commonDeleteRecursively(this, fileOrDirectory, z);
    }

    public final void deleteRecursively(Path fileOrDirectory) {
        Intrinsics.checkNotNullParameter(fileOrDirectory, "fileOrDirectory");
        deleteRecursively(fileOrDirectory, false);
    }

    /* JADX INFO: compiled from: FileSystem.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        public final FileSystem get(java.nio.file.FileSystem fileSystem) {
            Intrinsics.checkNotNullParameter(fileSystem, "<this>");
            return new NioFileSystemWrappingFileSystem(fileSystem);
        }
    }

    static {
        FileSystem jvmSystemFileSystem;
        try {
            Class.forName("java.nio.file.Files");
            jvmSystemFileSystem = new NioSystemFileSystem();
        } catch (ClassNotFoundException unused) {
            jvmSystemFileSystem = new JvmSystemFileSystem();
        }
        SYSTEM = jvmSystemFileSystem;
        Path.Companion companion = Path.Companion;
        String property = System.getProperty("java.io.tmpdir");
        Intrinsics.checkNotNullExpressionValue(property, "getProperty(...)");
        SYSTEM_TEMPORARY_DIRECTORY = Path.Companion.get$default(companion, property, false, 1, (Object) null);
        ClassLoader classLoader = ResourceFileSystem.class.getClassLoader();
        Intrinsics.checkNotNullExpressionValue(classLoader, "getClassLoader(...)");
        RESOURCES = new ResourceFileSystem(classLoader, false, null, 4, null);
    }
}
